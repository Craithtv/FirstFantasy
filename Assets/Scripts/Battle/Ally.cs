using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Battle
{public class Ally : Actor
{
    //specific Actor for a party memb

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

        StartCoroutine(GetPlayerCommand());
    }

    private IEnumerator GetPlayerCommand()
    {
        // while(true)
        // {
        //     if (Input.GetKeyDown(KeyCode.C))
        //     {
        //         Debug.Log("Command entered");
        //         break;
        //     }
        //     yield return null;
        // }
        CommandFetcher commandFetcher = new CommandFetcher(this);
        StartCoroutine(commandFetcher.Co_GetCommand());

        while (commandFetcher.Command is null)
        {
            yield return null;
        }

        StartCoroutine(commandFetcher.Command.Execute());

        while (!commandFetcher.Command.IsFinished)
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

        yield return new WaitForSeconds(.5f);
        elapsedTime = 0;
        
         Animator.Play("Moving");
         while ((Vector2)transform.position != startingPos)
        {
            transform.position = Vector2.Lerp(battlePos, startingPos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Animator.Play("Idle");
        IsTakingTurn = false;
    }
}
}