using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //Oversee turns, trigger next turn when order is done
    //End battle when over
    
    [SerializeField] private List<Actor> turnOrder = new List<Actor>();
    [SerializeField] private int turnNumber = 0;
    public static EnemyPack enemyPack;

    private bool setupComplete = false;

    public IReadOnlyList<Actor> TurnOrder => turnOrder;

    private void Awake() 
    {
        SpawnPartyMembers();
        SpawnEnemies();
    }

    private void Update() 
    {

        if(!setupComplete)
        {
            DetermineTurnOrder();
        }
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
            GameObject partyMember = Instantiate(member.ActorPrefab, spawnPos, Quaternion.identity);
            Ally ally = partyMember.GetComponent<Ally>();
            ally.Stats = member.Stats;
            turnOrder.Add(ally);
            spawnPos.y += 2;
            
        }
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i < enemyPack.Enemies.Count; i++) 
        {
            Vector2 spawnPos = new Vector2 (enemyPack.XSpawnCoordinates[i], enemyPack.YSpawnCoordinates[i]);
            GameObject enemyActor = Instantiate(enemyPack.Enemies[i].ActorPrefab, spawnPos, Quaternion.identity);
            Enemy enemy = enemyActor.GetComponent<Enemy>();
            enemy.Stats = enemyPack.Enemies[i].Stats;

            turnOrder.Add(enemy);
        }
    }

    private void DetermineTurnOrder()
    {
        turnOrder = TurnOrder.OrderByDescending(actor => actor.Stats.Initiative).ToList();
        foreach(Actor actor in TurnOrder)
        {
            Debug.Log($"{actor.name} {actor.Stats.SPD}");
        }
        turnOrder[0].StartTurn();
        setupComplete = true;
    }

    private void CheckForEnd()
    {
        //Look to see if all enemies dead
    }

    private void GoToNextTurn()
    {
        turnNumber = (turnNumber+1) % turnOrder.Count;
        turnOrder[turnNumber].StartTurn();
    }
}
