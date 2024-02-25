using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    World,
    Cutscene,
    Battle,
    Menu,
}

public class Game : MonoBehaviour
{
    private static DialogueWindow dialogueWindow;
    public static mainMenu mainMenu;
    public static GameState State {get; private set;}
    public static Map Map {get; private set;}
    public static Player Player {get; private set;}
   
    public static void ToggleMenu()
    {
        if (mainMenu.IsAnimating)
            return;
        if (mainMenu.IsOpen)
        {
            Debug.Log("closing menu");
            State = GameState.World;
            mainMenu.CloseMenu();
        }
        else
        {
            Debug.Log("open menu");
            State = GameState.Menu;
            mainMenu.OpenMenu();
        }
    }
    public static void StartDialogue(DialogueScene sceneToPlay)
    {
        State = GameState.Cutscene;
        dialogueWindow.Open(sceneToPlay);
    }
    public static void EndDialogue()
    {
        State = GameState.World;
    }

    [SerializeField] private Map startingMap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2Int startingCell;
    //[SerializeField] private DialogueWindow dialogueWindow;

    private void Awake()
    {
        dialogueWindow = FindObjectOfType<DialogueWindow>();
        mainMenu = FindObjectOfType<mainMenu>();

        if (Map == null)
        {
           Map = Instantiate(startingMap);
        }
        if (Player == null)
        {
            GameObject gameObject = Instantiate(playerPrefab, startingCell.Center2D(), Quaternion.identity);
            Player = gameObject.GetComponent<Player>();
        }
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(Map);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BattleManager.enemyPack = ResourceLoader.Load<EnemyPack>(ResourceLoader.TestPack);
            StartCoroutine(StartBattle());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndBattle();
        }
    }

    private IEnumerator StartBattle()
    {
        State = GameState.Battle;
        Instantiate(ResourceLoader.Load<GameObject>(ResourceLoader.BattleTransition));
        yield return new WaitForSeconds(1.5f);
        SceneLoader.LoadBattleScene();
    }

    private void EndBattle()
    {
        SceneLoader.ReloadSavedScenePostBattle();
        State = GameState.World;
    }
   
}
