using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public abstract class EnemyAI : MonoBehaviour
{
    protected Actor actor;
    protected BattleManager battleManager;

    protected virtual void Awake() 
    {
        battleManager = FindObjectOfType<BattleManager>();
        actor = GetComponent<Actor>();
    }
    public abstract ICommand ChooseAction();
}
}