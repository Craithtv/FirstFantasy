using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
namespace Battle
{public class Attack : ICommand
{
    private Actor attacker;
    private Actor defender;
    public Transform attackerTransform;
    public Transform defenderTransform;
    private float moveSpeed = .01f;

    private readonly Vector3 attackOffset = new Vector3(0.65f, 0, 0);

    public bool IsFinished{get; private set;} = false;

    public Attack(Actor attacker, Actor defender)
    {
        this.attacker = attacker;
        this.defender = defender;
        this.attackerTransform = attacker.GetComponent<Transform>();
        this.defenderTransform = defender.GetComponent<Transform>();
    }

    public IEnumerator Execute()
    {
        Vector3 targetPos;

        if (attacker is Ally)
            targetPos = defenderTransform.position - attackOffset;
        else 
            targetPos = defenderTransform.position + attackOffset;

        attacker.Animator.Play("Moving");
        while(attackerTransform.position != targetPos)
        {
            attackerTransform.position = Vector3.MoveTowards(attackerTransform.position, targetPos, moveSpeed);
            yield return null;
        }

        attacker.Animator.Play("Attack");
        yield return new WaitForSeconds(1f);
        while(attacker.Animator.IsAnimating())
        {
            yield return null;
        }
        attacker.Animator.Play("Idle");

        Calculate.AttackDamage(attacker, defender);

        IsFinished = true;
    }
}
}