using System.Collections;
using System.Collections.Generic;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

[System.Serializable]

public class BattleStats
{
   private const int MAXIMUM_POSSIBLE_LVL = 99;
   private const int MAXIMUM_POSSIBLE_HP = 999;
   private const int MAXIMUM_POSSIBLE_STR = 99;
   private const int MAXIMUM_POSSIBLE_DEF = 99;
   private const int MAXIMUM_POSSIBLE_SPD = 99;

   [SerializeField] private int level;
   [SerializeField] private int hp;
   [SerializeField] private int maxHp;
   [SerializeField] private int str;
   [SerializeField] private int def;
   [SerializeField] private int spd;

   public BattleStats(int level, int hp, int maxHp, int str, int def, int spd)
   {
    this.level = level;
    this.hp = hp;
    this.maxHp = maxHp;
    this.str = str;
    this.def = def;
    this.spd = spd;
   }

   public int Initiative => SPD + Random.Range(-1, 2); //remove Random if changing to strictly math. Only adds variation

   public int LVL
   {
    get => level;
    set
    {
        level = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_LVL);
    }
   }

   public int HP
   {
    get => hp;
    set
    {
        hp = Mathf.Clamp(value, 0, maxHp);
    }
   }

   public int MaxHp
   {
    get => maxHp;
    set
    {
        hp = Mathf.Clamp(value, 1, MAXIMUM_POSSIBLE_HP);
    }
   }

   public int STR
   {
    get => str;
    set
    {
        str = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_STR);
    }
   }

   public int DEF
   {
    get => def;
    set
    {
        def = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_DEF);
    }
   }

   public int SPD
   {
    get => spd;
    set
    {
        spd = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_SPD);
    }
   }
}
