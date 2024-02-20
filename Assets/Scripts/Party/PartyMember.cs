using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMember
{
    public string name {get; private set;}
    public GameObject actorPrefab {get; private set;}
    public BattleStats stats {get; private set;}
    public Image portrait {get; private set;}

    public string job {get; private set;} = "Boss Ass Mfer";

    public PartyMember(string Name, Image Portrait, string Job, GameObject ActorPrefab, BattleStats Stats)
    {
        this.name = Name;
        this.job = Job;
        this.portrait = Portrait;
        this.actorPrefab = ActorPrefab;
        this.stats = Stats;
    }

}
