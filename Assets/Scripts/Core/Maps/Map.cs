using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

namespace Core
{public class Map : MonoBehaviour
{
    [SerializeField] private BattleRegion region;
    public Grid Grid {get; private set;}
    public Dictionary<Vector2Int, MonoBehaviour> OccupiedCells {get; private set;}
    public Dictionary<Vector2Int, Transfer> Exits {get; private set;}
    public BattleRegion Region => region;

    private void Awake() 
    {
        Grid = GetComponent<Grid>();
        OccupiedCells = new Dictionary<Vector2Int, MonoBehaviour>();
        Exits = new Dictionary<Vector2Int, Transfer>();
        OccupiedCells.Clear();
    }

    
}
}