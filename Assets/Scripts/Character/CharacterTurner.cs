using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterTurner
{
    private Character character;
    public Vector2Int facing {get; private set;} = Direction.Down;

    public CharacterTurner(Character character)
    {
        this.character = character;
    }

    public void Turn(Vector2Int direction) 
    {
        if (direction.IsBasic())
        {
            facing = direction;
        }
    }

    public void TurnAround() => facing = new Vector2Int(-facing.x, -facing.y);

    public void TurnToPlayer()
    {
        Player player = Game.Player;

        if (player.CurrentCell.x > character.CurrentCell.x)
        {
            Turn(Direction.Right);
        }
        else if (player.CurrentCell.x < character.CurrentCell.x)
        {
            Turn(Direction.Left);
        }
        else if (player.CurrentCell.y > character.CurrentCell.y)
        {
            Turn(Direction.Up);
        }
        else
        {
            Turn(Direction.Down);
        }
    }


    
}
