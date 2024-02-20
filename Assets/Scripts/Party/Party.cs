using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public static class Party
{
    private static List<PartyMember> activeMembers = new List<PartyMember>();
    private static List<PartyMember> reserveMembers = new List<PartyMember>();
    public static IReadOnlyList<PartyMember> ActiveMembers => activeMembers;

    static Party()
    {
        BattleStats thythorStats = new BattleStats (5, 0, 27, 10, 13, 14);
       
        PartyMember thythor = new PartyMember(
            "Thythor",
            null,
            "Warlock",
            Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"), 
            thythorStats);

        activeMembers.Add(thythor);
    }

    public static void AddActiveMember(PartyMember memberToAdd)
    {
        if (activeMembers.Contains(memberToAdd))
        {
            return;
        }

        activeMembers.Add(memberToAdd);
        reserveMembers.Remove(memberToAdd);
    }

    public static void RemoveActiveMember(PartyMember memberToRemove)
    {
        if (!activeMembers.Contains(memberToRemove))
        {
            return;
        }
        
        activeMembers.Remove(memberToRemove);
        reserveMembers.Add(memberToRemove);
    }
}
