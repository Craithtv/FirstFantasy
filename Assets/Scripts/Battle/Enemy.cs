using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{public class Enemy : Actor
{
    private EnemyAI ai;

    protected override void Awake()
    {
        base.Awake();
        ai = GetComponent<EnemyAI>();
        WasDeafeated += OnDeath;
    }

    public override void StartTurn()
    {
       IsTakingTurn = true;
       StartCoroutine(MoveToCenter());
    }

    private IEnumerator MoveToCenter()
    {
        float elapsedTime = 0f;

        Animator.Play("Moving");

        while ((Vector2)transform.position != battlePos)
        {
            transform.position = Vector2.Lerp(startingPos, battlePos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Animator.Play("Idle");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(EnemyChooseAction());
    }

    private IEnumerator EnemyChooseAction()
    {
        ICommand command;
        command = ai.ChooseAction();
        StartCoroutine(command.Execute());

        while (!command.IsFinished)
        {
            yield return null;
        }

        StartCoroutine(EndTurn());
    }

    private IEnumerator EndTurn()
    {
         float elapsedTime = 0f;
         Vector2 currentPos = transform.position;

         Animator.Play("Moving");

        while ((Vector2)transform.position != battlePos)
        {
            transform.position = Vector2.Lerp(currentPos, battlePos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        Animator.Play("Idle");
        yield return new WaitForSeconds(0.5f);

        elapsedTime = 0;
        Animator.Play("Moving");
        while ((Vector2)transform.position != startingPos)
        {
            transform.position = Vector2.Lerp(battlePos, startingPos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Animator.Play(stateName: "Idle");
        IsTakingTurn = false;
    }

    private void OnDeath() => StartCoroutine(Die());

    private IEnumerator Die()
    {
        WasDeafeated -= OnDeath;
        Animator.Play("Death");
        yield return null;
        while (Animator.IsAnimating())
            yield return null;
        Destroy(this.gameObject);
    }
}
}