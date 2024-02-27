using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

namespace Core
{public class Map : MonoBehaviour
{
    public Grid Grid {get; private set;}
    public Dictionary<Vector2Int, MonoBehaviour> OccupiedCells {get; private set;}
    public Dictionary<Vector2Int, Exit> Exits {get; private set;}

    private void Awake() 
    {
        Grid = GetComponent<Grid>();
        OccupiedCells = new Dictionary<Vector2Int, MonoBehaviour>();
        Exits = new Dictionary<Vector2Int, Exit>();
        OccupiedCells.Clear();
    }

    
}
}