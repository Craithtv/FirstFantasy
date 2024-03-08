using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class WraithAI : EnemyAI
{
    public override ICommand ChooseAction()
    {
       Actor defender = GetRandomTarget();
        
        return new Attack(actor, defender);
    }

    private Actor GetRandomTarget()
    {
        return battleManager.Allies[Random.Range(0, battleManager.Allies.Count)];
    }
}
}