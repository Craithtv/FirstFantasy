using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Codice.Client.Common;
using UnityEngine;
using UnityEngine.UI;
using Battle;

[CreateAssetMenu(fileName ="New Party Member", menuName = "New Party Member")]

public class PartyMember : ScriptableObject
{

    [SerializeField] private string displayName;
    [SerializeField] private GameObject actorPrefab;
    [SerializeField] private BattleStats stats;
    [SerializeField] private Sprite menuPortrait;
    [SerializeField] private BattlePortrait battlePortrait;
    [SerializeField] private string job = "BAMF";

    public string Name => displayName;
    public GameObject ActorPrefab => actorPrefab;
    public BattleStats Stats => stats;
    public Sprite MenuPortrait => menuPortrait;
    public BattlePortrait BattlePortrait => battlePortrait;
    public string Job => job;
    

}
