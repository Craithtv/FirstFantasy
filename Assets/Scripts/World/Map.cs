using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Grid Grid {get; private set;}
    public Dictionary<Vector2Int, MonoBehaviour> OccupiedCells {get; private set;} = new Dictionary<Vector2Int, MonoBehaviour>();


    private void Awake() 
    {
        Grid = GetComponent<Grid>();
        OccupiedCells.Clear();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
