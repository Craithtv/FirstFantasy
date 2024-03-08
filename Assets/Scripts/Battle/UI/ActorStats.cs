using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Battle

{public class ActorStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hp;

    private BattleManager battleManager;
    private Actor actor;

    private void Awake() 
    {
        actor = GetComponentInParent<Actor>();
        battleManager  = FindObjectOfType<BattleManager>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleManager.setupComplete)
            return;

        hp.text = $"{actor.Stats.HP}/{actor.Stats.MaxHp}";

        if(((float)actor.Stats.HP/(float)actor.Stats.MaxHp) < .2f)
            hp.color= Color.yellow;
        else
            hp.color = Color.white;
    }
}
}