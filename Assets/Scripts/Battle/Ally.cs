using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Actor
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

        while ((Vector2)transform.position != battlePos)
        {
            transform.position = Vector2.Lerp(startingPos, battlePos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(GetPlayerCommand());
    }

    private IEnumerator GetPlayerCommand()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Command entered");
                break;
            }
            yield return null;
        }
        Debug.Log("Ended GetPlayerCommand");
        StartCoroutine(EndTurn());
    }

    private IEnumerator EndTurn()
    {
         float elapsedTime = 0f;
         Vector2 currentPos = transform.position;

         while ((Vector2)transform.position != startingPos)
        {
            transform.position = Vector2.Lerp(currentPos, startingPos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        IsTakingTurn = false;
    }
}
