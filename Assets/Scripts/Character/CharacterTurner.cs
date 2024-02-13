using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterTurner
{
    public Vector2Int facing {get; private set;} = Direction.Down;

    public void Turn(Vector2Int direction) 
    {
        if (direction.IsBasic())
        {
            facing = direction;
        }
    }

    public void TurnAround() => facing = new Vector2Int(-facing.x, -facing.y);
    
}
