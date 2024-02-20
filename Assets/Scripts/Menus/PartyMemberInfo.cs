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
        partyMember = Party.ActiveMembers[0];
        memberName.text = partyMember.name;
        memberPortrait = partyMember.portrait;
        GetStats();
    }

    public void GetStats()
    {
        string levelJob = $"Level {partyMember.stats.LVL} {partyMember.job}";
        memberLevelClass.text = levelJob;

        memberHP.text = $"HP: {partyMember.stats.HP.ToString()}/{partyMember.stats.MaxHp}";
        memberMana.text = "MP 3/4";

        memberBaseSTR.text = partyMember.stats.STR.ToString();
        memberBaseSPD.text = partyMember.stats.SPD.ToString();
        memberBaseDEF.text = partyMember.stats.DEF.ToString();

        memberEquipdSTR.text = partyMember.stats.STR.ToString();
        memberEquipdSPD.text = partyMember.stats.SPD.ToString();
        memberEquipdDEF.text = partyMember.stats.DEF.ToString();
    }
}
