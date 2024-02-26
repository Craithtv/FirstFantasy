using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{public static class Extensions
{
    public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
    {
        Vector3 position = gameObject.transform.position;

        return (Vector2Int) grid.WorldToCell(position);
    }

    public static Vector2 GetCellCenter2D(this Grid grid, Vector2Int cell)
    {
        Vector3Int threeDimensionCell = new Vector3Int(cell.x, cell.y, 0);
        
        return grid.GetCellCenterWorld(threeDimensionCell);
    }

    public static bool IsAnimating(this Animator animator, int layer=0)
    {
        bool result = (animator.GetCurrentAnimatorStateInfo(layer).normalizedTime >= 0 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1);
        return result;
    }

     public static bool IsBasic(this Vector2Int direction)
    {
        if (direction == Direction.Up || direction == Direction.Down || direction == Direction.Right || direction == Direction.Left)
        {
            return true;
        }

        return false;
    }
}
}