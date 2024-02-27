using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common.Merge;
using Unity.VisualScripting.YamlDotNet.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using Battle;

namespace Core
{

public class Game : MonoBehaviour
{
    public static Game Manager {get; private set;}
    [SerializeField] private Map startingMap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2Int startingCell;
    [SerializeField] private DialogueWindow dialogueWindow;
    [SerializeField] public mainMenu mainMenu;
    [SerializeField] private GameObject battleTransitionPrefab;
    public GameState State {get; private set;}
    public Map Map {get; private set;}
    public Player Player {get; private set;}
   
   
    private void Awake()
    {
        if (Manager != null && Manager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Manager = this;
        }

        DontDestroyOnLoad(this);
        
    }

    private void Start() 
    {
        Map = Instantiate(startingMap);
        Player = Instantiate(playerPrefab, startingCell.Center2D(), Quaternion.identity).GetComponent<Player>();
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(Map);
    }


    public void ToggleMenu()
    {
        if (mainMenu.IsAnimating || State == GameState.Cutscene)
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
    public void StartDialogue(Dialogue sceneToPlay)
    {
        State = GameState.Cutscene;
        dialogueWindow.Open(sceneToPlay);
    }
    public void EndDialogue() =>  State = GameState.World;

    public IEnumerator StartBattle(EnemyPack pack)
    {
        State = GameState.Battle;
        BattleManager.enemyPack = pack;
        Animator animator = PlayBattleTransition();
        while (animator.IsAnimating()) yield return null;
        SceneLoader.LoadBattleScene();
    }

    private Animator PlayBattleTransition()
    {
        Animator animator = Instantiate(battleTransitionPrefab, Player.transform.position, Quaternion.identity).GetComponent<Animator>();
        return animator;
    }

    public void EndBattle()
    {
        SceneLoader.ReloadSavedScenePostBattle();
        State = GameState.World;
    }

    public void AdvanceDialogue()
    {
        if (!dialogueWindow.IsOpen || State != GameState.Cutscene || dialogueWindow.IsAnimating)
        {
            Debug.Log("Advancing");
            return;
        }
        dialogueWindow.GoToNextLine();
    }

    public void LoadMap(Map newMap, Vector2Int destinationCell)
    {
        Map oldMap = Map;
        Map = Instantiate(newMap);
        Destroy(oldMap.gameObject);
        Player.transform.position = destinationCell.Center2D();
    }
   
}
}