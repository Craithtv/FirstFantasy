using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //Oversee turns, trigger next turn when order is done
    //End battle when over
    
    [SerializeField] private List<Actor> TurnOrder = new List<Actor>();
    [SerializeField] private int turnNumber = 0;

    private void Awake() 
    {
        SpawnPartyMembers();
    }

    private void Update() 
    {
        if (TurnOrder[turnNumber].IsTakingTurn) return;

        else
        {
            CheckForEnd();
            GoToNextTurn();
        }
    }

    private void SpawnPartyMembers()
    {
        Vector2 spawnPos = new Vector2(-5, -2);
        foreach(PartyMember member in Party.ActiveMembers)
        {
            GameObject partyMember = Instantiate(member.actorPrefab, spawnPos, Quaternion.identity);
            spawnPos.y += 2;
            TurnOrder.Add(partyMember.GetComponent<Ally>());
        }
    }

    private void CheckForEnd()
    {
        //Look to see if all enemies dead
    }

    private void GoToNextTurn()
    {
        turnNumber = (turnNumber+1) % TurnOrder.Count;
        TurnOrder[turnNumber].StartTurn();
    }
}
