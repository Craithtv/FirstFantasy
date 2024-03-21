using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattlePortrait : MonoBehaviour
{
    private BattleManager battleManager;
    
    private RectTransform rectTransform;
    private TurnBar turnBar;

    private Actor actor;

    private void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
        rectTransform = GetComponent<RectTransform>();
        turnBar = FindObjectOfType<TurnBar>();

        foreach(GameObject slot in turnBar.Slots)
        {
            if (slot.GetComponentInChildren<BattlePortrait>() == null)
            {
                rectTransform.SetParent(slot.transform, false);
                int index = slot.transform.GetSiblingIndex() - 1;
                actor = battleManager.TurnOrder[index];
                break;
            }
        }
    }

    private void Update() 
    {
        rectTransform.SetParent(turnBar.Slots[actor.TurnNumber].transform, false);
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, new Vector2(0,0), 1f);
    }
}
}