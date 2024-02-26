using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{public class CharacterMover
{
    private Character character;
    private Transform transform;
    private Map map => Game.Manager.Map;
    private const float timeToTryMoveSquare = .275f;
    public bool isMoving {get; private set;} = false;
    public CharacterMover(Character character)
    {
        this.character = character;
        this.transform = character.transform;

    }

    public void TryMove(Vector2Int direction)
    {
        if (isMoving || !direction.IsBasic()){return;}

        character.Turner.Turn(direction);
        Vector2Int targetCell = character.CurrentCell + direction;
       
        if(CanMoveToCell(targetCell, direction))
        {
            map.OccupiedCells.Add(character.CurrentCell + direction, character);
            map.OccupiedCells.Remove(character.CurrentCell);
            character.StartCoroutine(TryMover(direction));
        }
        
    }

    private bool CanMoveToCell(Vector2Int targetCell, Vector2Int direction) 
    {
        if (IsCellOccupied(targetCell))
        {
           return false;
        }

        Ray2D ray = new Ray2D(character.CurrentCell.Center2D(), direction);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

       foreach (RaycastHit2D hit in hits)
       {
            if (hit.distance < map.Grid.cellSize.x)
            {
                return false;
            }
       }  
       return true;    
    }

    private bool IsCellOccupied(Vector2Int cell) 
    {
        return (map.OccupiedCells.ContainsKey(cell));
    }

    public IEnumerator TryMover(Vector2Int direction)
    {
        isMoving = true;

        Vector2 startingPos = character.CurrentCell.Center2D();
        Vector2 endingPos = (character.CurrentCell + direction).Center2D();

        float elapsedTime = 0;

        while ((Vector2)transform.position != endingPos)
        {
            transform.position = Vector2.Lerp(startingPos, endingPos, elapsedTime / timeToTryMoveSquare);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endingPos;
        isMoving = false;

    }
}
}