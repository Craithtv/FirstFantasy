using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Core;

namespace Battle
{public class BattleManager : MonoBehaviour
{
    //Oversee turns, trigger next turn when order is done
    //End battle when over
    
    [SerializeField] private List<Actor> turnOrder = new List<Actor>();
    private TurnBar turnbar;
    private List<Ally> allies  = new List<Ally>();
    private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private int turnNumber = 0;
    public static EnemyPack enemyPack;

    private bool setupComplete = false;

    public IReadOnlyList<Actor> TurnOrder => turnOrder;
    public IReadOnlyList<Ally> Allies => allies;
    public IReadOnlyList<Enemy> Enemies => enemies;


    private void Awake() 
    {

        turnbar = FindObjectOfType<TurnBar>();
        SpawnPartyMembers();
        SpawnEnemies();
        turnbar.SpawnPortraitSlots(turnOrder);
        turnbar.SpawnActorPortraits();
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
       int partyCount = Party.ActiveMembers.Count;

        foreach(PartyMember member in Party.ActiveMembers)
        {
            GameObject partyMember = Instantiate(member.ActorPrefab, new Vector2(-20, 0), Quaternion.identity);
            Ally ally = partyMember.GetComponent<Ally>();
            ally.Stats = member.Stats;
            turnOrder.Add(ally);
            allies.Add(ally);
            
            
        }
        List<Vector2> spawnPos = new List<Vector2>();

    
            switch(partyCount)
            {
                case 1: 
                    spawnPos.Add(new Vector2(-4, 0.25f));
                    break;
                case 2: 
                    spawnPos.Add(new Vector2(-4, -0.1f));
                    spawnPos.Add(new Vector2(-4, 0.8f));
                    break;
                case 3:
                    spawnPos.Add(new Vector2(-5, -2));
                    spawnPos.Add(new Vector2(-4.3f, 0));
                    spawnPos.Add(new Vector2(-5, 2));
                    break;
                case 4:
                    spawnPos.Add(new Vector2(-5, -2));
                    spawnPos.Add(new Vector2(-4, -0.75f));
                    spawnPos.Add(new Vector2(-4, 0.75f));
                    spawnPos.Add(new Vector2(-5, 2));
                    break;
        }

        int spawnPositionIndex = 0;

            foreach(Ally ally in allies)
            {
                ally.transform.position = spawnPos[spawnPositionIndex];
                spawnPositionIndex++;
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
            enemies.Add(enemy);
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
}