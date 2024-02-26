using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;

namespace Core
{
    public class PartyMemberInfo : MonoBehaviour
{
    private PartyMember partyMember;

    [SerializeField]private Image memberPortrait;
    [SerializeField]private TextMeshProUGUI memberName;
    [SerializeField]private TextMeshProUGUI memberLevelClass;
    [SerializeField]private TextMeshProUGUI memberHP;
    [SerializeField]private TextMeshProUGUI memberMana;
    [SerializeField]private TextMeshProUGUI memberBaseSTR;
    [SerializeField]private TextMeshProUGUI memberBaseDEF;
    [SerializeField]private TextMeshProUGUI memberBaseSPD;
    [SerializeField]private TextMeshProUGUI memberEquipdSTR;
    [SerializeField]private TextMeshProUGUI memberEquipdDEF;
    [SerializeField]private TextMeshProUGUI memberEquipdSPD;
    
    void Start()
    {
        int siblingIndex = this.gameObject.transform.GetSiblingIndex();
        partyMember = Party.ActiveMembers[siblingIndex];
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        BattleStats stats = partyMember.Stats;
        memberName.text = partyMember.name;
        memberPortrait.sprite = partyMember.Portrait;

        string levelJob = $"Level {stats.LVL} {partyMember.Job}";
        memberLevelClass.text = levelJob;

        memberHP.text = $"HP: {stats.HP.ToString()}/{stats.MaxHp}";
        memberMana.text = "MP 3/4";

        memberBaseSTR.text = $"STR: {stats.STR}";
        memberBaseSPD.text = $"SPD: {stats.SPD}";
        memberBaseDEF.text = $"DEF: {stats.DEF}";

        memberEquipdSTR.text = $"STR: +{stats.STR}";
        memberEquipdSPD.text = $"SPD: +{stats.SPD}";
        memberEquipdDEF.text = $"DEF: +{stats.DEF}";
    }
}
}