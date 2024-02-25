using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    //private static int debugSceneBuildIndex = 1;
    private static int battleSceneBuildIndex = 2;
    private static int savedSceneBuildIndex;
    private static Vector2 savedPlayerLocation;

    public static void LoadBattleScene()
    {
        Game.Map.gameObject.SetActive(false);
        //caches the player's current info
        savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        savedPlayerLocation = Game.Player.CurrentCell.Center2D();

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
        Game.Map.gameObject.SetActive(true);
        Game.Player.transform.position = savedPlayerLocation;
        Game.Player.gameObject.SetActive(true);
        SceneManager.sceneLoaded -= RestoreMapAndPlayer;
    }

    public static void DisabledPlayerObject(Scene scene, LoadSceneMode mode)
    {
        Game.Player.gameObject.SetActive(false);
    }
}
