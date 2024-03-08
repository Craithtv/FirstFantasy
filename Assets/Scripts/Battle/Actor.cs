using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Codice.CM.Common;
namespace Battle
{public abstract class Actor : MonoBehaviour
{ //both pcs and npcs
  //store actor stats/methods for taking a turn
    protected Vector2 battlePos = new Vector2(0, 0);
    protected Vector2 startingPos;

    public Animator Animator {get; protected set;}
    protected BattleManager battleManager;
    public bool IsTakingTurn {get; protected set;} = false;
    public BattleStats Stats {get; set;}
    public int TurnNumber => battleManager.TurnOrder.IndexOf(this);

    protected virtual void Awake() 
    {
      battleManager = FindObjectOfType<BattleManager>();
      Animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        startingPos = transform.position;
    }

    public abstract void StartTurn();


}
}