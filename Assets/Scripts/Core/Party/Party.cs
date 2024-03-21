using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using Battle;
namespace Core
{public static class Party
{
    private static List<PartyMember> activeMembers = new List<PartyMember>();
    private static List<PartyMember> reserveMembers = new List<PartyMember>();
    public static IReadOnlyList<PartyMember> ActiveMembers => activeMembers;
    public static IReadOnlyList<PartyMember> ReserveMembers => reserveMembers;


    static Party()
        {
            GenerateStartingParty();
        }

        private static void GenerateStartingParty()
        {
            PartyMember Korb = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Korb));
            PartyMember Saph = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Saph));
            PartyMember Thy = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Thy));
            PartyMember Zaash = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Zaash));
            AddActiveMember(Korb);
            AddActiveMember(Saph);
            AddActiveMember(Thy);
            AddActiveMember(Zaash);
            BattleStats thythorStats = new BattleStats(5, 0, 27, 10, 13, 14);
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
}