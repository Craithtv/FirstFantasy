using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
        memberName.text = partyMember.name;
        memberPortrait.sprite = partyMember.Portrait;
        GetStats();
    }

    public void GetStats()
    {
        string levelJob = $"Level {partyMember.Stats.LVL} {partyMember.Job}";
        memberLevelClass.text = levelJob;

        memberHP.text = $"HP: {partyMember.Stats.HP.ToString()}/{partyMember.Stats.MaxHp}";
        memberMana.text = "MP 3/4";

        memberBaseSTR.text = $"STR: {partyMember.Stats.STR}";
        memberBaseSPD.text = $"SPD: {partyMember.Stats.SPD}";
        memberBaseDEF.text = $"DEF: {partyMember.Stats.DEF}";

        memberEquipdSTR.text = $"STR: +{partyMember.Stats.STR}";
        memberEquipdSPD.text = $"SPD: +{partyMember.Stats.SPD}";
        memberEquipdDEF.text = $"DEF: +{partyMember.Stats.DEF}";
    }
}
