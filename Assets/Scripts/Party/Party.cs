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
        BattleStats johnStats = new BattleStats (10, 10, 3, 2, 3);
        BattleStats deanStats = new BattleStats (10, 10, 3, 2, 8);
        BattleStats sammyStats = new BattleStats (10, 10, 3, 2, 10);
        PartyMember John = new PartyMember(Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"), johnStats);
        PartyMember Dean = new PartyMember(Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"), deanStats);
        PartyMember Sammy = new PartyMember(Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"), sammyStats);

        activeMembers.Add(John);
        activeMembers.Add(Dean);
        activeMembers.Add(Sammy);
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
