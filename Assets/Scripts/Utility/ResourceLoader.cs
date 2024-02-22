using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceLoader
{
    public static string enemyPackPath = "ScriptableObjects/EnemyPacks/";
    public static string enemyDataPath = "ScriptableObjects/EnemyData/";
    public static string partyMemberPath = "ScriptableObjects/PartyMembers/";

    //enemy pack
    public static string TestPack = enemyPackPath + "TestPack";

    //enemy data
    public static string TestEnemy = enemyDataPath + "TestEnemy";

    //party members
    public static string Korb = partyMemberPath + "Korburina";
    public static string Saph = partyMemberPath + "Saphielle";
    public static string Thy = partyMemberPath + "Thythor";

    //other
    public static string BattleTransition = "BattleTransition";

    public static T Load<T>(string resource) where T:Object
    {
        T loadedItem = Resources.Load<T>(resource);

        if (loadedItem != null)
        {
            return loadedItem;
        }
        else
        {
            Debug.LogError($"Could not locate {resource}");
            return null;
        }
    }
}
