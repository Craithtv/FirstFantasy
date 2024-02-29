using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Core
{public static class SceneLoader
{
    //private static int debugSceneBuildIndex = 1;
    private static int battleSceneBuildIndex = 2;
    private static int savedSceneBuildIndex;
    private static Vector2 savedPlayerLocation;

    public static void LoadBattleScene()
    {
        Debug.Log("Loading Battle");
        GameObject.DontDestroyOnLoad(Game.Manager.Map);

        Debug.Log("Saving map");
        Game.Manager.Map.gameObject.SetActive(false);

        //caches the player's current info
        savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        savedPlayerLocation = Game.Manager.Player.CurrentCell.Center2D();

        SceneManager.LoadScene(battleSceneBuildIndex);
        SceneManager.sceneLoaded += DisabledPlayerObject;
    }

    public static void ReloadSavedScenePostBattle()
    {
        SceneManager.sceneLoaded += RestoreMapAndPlayer;
        if (savedSceneBuildIndex == 0)
        {
            savedSceneBuildIndex++;
        }
        SceneManager.LoadScene(savedSceneBuildIndex);
    }

    public static void RestoreMapAndPlayer(Scene scene, LoadSceneMode mode)
    {
        Game.Manager.Map.gameObject.SetActive(true);
        Game.Manager.Player.transform.position = savedPlayerLocation;
        Game.Manager.Player.gameObject.SetActive(true);
        SceneManager.sceneLoaded -= RestoreMapAndPlayer;
    }

    public static void DisabledPlayerObject(Scene scene, LoadSceneMode mode)
    {
        Game.Manager.Player.gameObject.SetActive(false);
    }
}
}