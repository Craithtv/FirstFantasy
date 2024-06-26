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

    private List<RectTransform> slotRects = new List<RectTransform>();

    private void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
        rectTransform = GetComponent<RectTransform>();
        turnBar = FindObjectOfType<TurnBar>();

        foreach(GameObject slot in turnBar.Slots)
        {
            slotRects.Add(slot.GetComponent<RectTransform>()) ;

        }

        foreach(GameObject slot in turnBar.Slots)
        {
            if (slot.GetComponentInChildren<BattlePortrait>() == null)
            {
                rectTransform.SetParent(slot.transform, false);
                int index = slot.transform.GetSiblingIndex() - 1;
                actor = battleManager.TurnOrder[index];
                if (actor is Enemy enemy)
                    enemy.WasDeafeated += RemovePortrait;
                break;
            }
        }
    }

    private void Start() {
        this.gameObject.transform.SetParent(turnBar.transform, false);
    }

    private void Update() 
    {
        RectTransform slotRect = slotRects[actor.TurnNumber];
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, slotRect.anchoredPosition, 1f);
    }

    private void RemovePortrait()
    {
        (actor as Enemy).WasDeafeated -= RemovePortrait;
        GameObject slot = turnBar.Slots[actor.TurnNumber];
        Destroy(this.gameObject);
        Destroy(slot);
        turnBar.Slots.Remove(slot);
    }
}
}