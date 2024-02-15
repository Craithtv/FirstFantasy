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
        //caches the player's current info
        savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        savedPlayerLocation = Game.Player.CurrentCell.Center2D();

        Game.Player.gameObject.SetActive(false);
        SceneManager.LoadScene(battleSceneBuildIndex);
    }

    public static void ReloadSavedScenePostBattle()
    {
        SceneManager.sceneLoaded += RestorePlayer;
        SceneManager.LoadScene(savedSceneBuildIndex);
    }

    public static void RestorePlayer(Scene scene, LoadSceneMode mode)
    {
        Game.Player.transform.position = savedPlayerLocation;
        Game.Player.gameObject.SetActive(true);
        SceneManager.sceneLoaded -= RestorePlayer;
    }
}
