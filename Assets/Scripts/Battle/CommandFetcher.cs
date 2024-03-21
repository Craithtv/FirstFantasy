using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
public class CommandFetcher
{
    private BattleManager battleManager;
    private Actor actor;
    public ICommand Command {get; private set;}

    public CommandFetcher(Actor actor)
    {
        this.actor = actor;
        battleManager = GameObject.FindObjectOfType<BattleManager>();
    }
    public IEnumerator Co_GetCommand()
    {
        while (Command == null)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Command = new Attack(actor, battleManager.Enemies[0]);
            }

            yield return null;
        }
    }
    
}
}