using System.Collections;
using System.Collections.Generic;
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
    public static GameState State {get; private set;}
    public static Map Map {get; private set;}
    public static Player Player {get; private set;}
    [SerializeField] private Map startingMap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2Int startingCell;

    private void Awake()
    {
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BattleManager.enemyPack = Resources.Load<EnemyPack>("ScriptableObjects/EnemyPacks/TestPack");
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
        Instantiate(Resources.Load<GameObject>("BattleTransition"), Player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        SceneLoader.LoadBattleScene();
    }

    private void EndBattle()
    {
        SceneLoader.ReloadSavedScenePostBattle();
        State = GameState.World;
    }
   
}
