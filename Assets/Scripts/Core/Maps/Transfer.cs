using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using PlasticGui;
using UnityEngine;

namespace Core
{    public class Transfer : MonoBehaviour
    {
        private Map currentMap;
        private Vector2Int exitCell;
        [SerializeField] private int id;

        [SerializeField] private Map newMap;
        [SerializeField] private int destinationId;

        public int Id => id;
        public Vector2Int Cell => exitCell;

       private void Awake() 
       {
            currentMap = FindObjectOfType<Map>();
            Debug.Log("Finding map");

            if(currentMap == null)
          {
               Debug.LogError("No Map object found in the scene!");
               return;
          }
    
          if(currentMap.Grid == null)
          {
               Debug.LogError("Grid component is not assigned in the Map object!");
               return;
          }
          exitCell = currentMap.Grid.GetCell2D(this.gameObject);

       }

       private void Start() 
       {
            currentMap.Exits.Add(exitCell, this);
       }

       public void TeleportPlayer()
       {
        Game.Manager.LoadMap(newMap, destinationId);
       }
    }
}

