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
        PartyMember John = new PartyMember(Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"));
        PartyMember Dean = new PartyMember(Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"));
        PartyMember Sammy = new PartyMember(Resources.Load<GameObject>("PartyBattlerPrefabs/Party1"));

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
