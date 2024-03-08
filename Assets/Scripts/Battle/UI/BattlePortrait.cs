using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattlePortrait : MonoBehaviour
{
    private BattleManager battleManager;
    private static int currentSlotIndex = 0;
    private RectTransform rectTransform;
    private TurnBar turnBar;

    private Actor actor;

    private void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
        rectTransform = GetComponent<RectTransform>();
        turnBar = FindObjectOfType<TurnBar>();

        rectTransform.SetParent(turnBar.Slots[currentSlotIndex].transform, false);
        actor = battleManager.TurnOrder[currentSlotIndex];
        currentSlotIndex++;
    }

    private void Update() 
    {
        rectTransform.SetParent(turnBar.Slots[actor.TurnNumber].transform, false);
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, new Vector2(0,0), 1f);
    }
}
}