using System.Collections;
using System.Collections.Generic;
//using System.Numerics;

using UnityEngine;

namespace Battle
{public class TurnIndicator : MonoBehaviour
{
    private TurnBar turnBar;
    private RectTransform rectTransform;
    private BattleManager battleManager;

    private List<RectTransform> slots = new List<RectTransform>();

    private void Awake() 
    {
        turnBar = GetComponentInParent<TurnBar>();
        rectTransform = GetComponent<RectTransform>();
        battleManager = FindObjectOfType<BattleManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject slot in turnBar.Slots)
        {
            slots.Add(slot.GetComponent<RectTransform>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = rectTransform.position;
        Vector2 targetPos = slots[battleManager.TurnNumber].position;

        float speed = 1f;

        if(battleManager.TurnNumber == 0)
            speed = 3f;
        
        rectTransform.position = Vector2.MoveTowards(currentPos, targetPos + new Vector2(0, -100), speed);
            
    }
}
}