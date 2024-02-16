using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember
{
    public GameObject actorPrefab {get; private set;}

    public BattleStats Stats {get; private set;}

    public PartyMember(GameObject actorPrefab, BattleStats stats)
    {
        this.actorPrefab = actorPrefab;
        this.Stats = stats;
    }

}
