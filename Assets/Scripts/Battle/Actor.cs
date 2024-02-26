using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Battle
{public abstract class Actor : MonoBehaviour
{ //both pcs and npcs
  //store actor stats/methods for taking a turn
    protected Vector2 battlePos = new Vector2(0, 0);
    protected Vector2 startingPos;
    public bool IsTakingTurn {get; protected set;} = false;
    public BattleStats Stats {get; set;}

    protected virtual void Start()
    {
        startingPos = transform.position;
    }

    public abstract void StartTurn();


}
}