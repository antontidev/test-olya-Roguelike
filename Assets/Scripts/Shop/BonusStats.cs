using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public struct BonusStats
{
    public int DefenceBuff;
    public int DamageBuff;
    public int HealthBuff;

    public Image BonusImage;
    public string Name;

    public float Chance; //percent

    public BonusStats(int defenceBuff, 
        int damageBuff, 
        int healthBuff, 
        Image bonusImage, 
        string name, 
        float chance)
    {
        DefenceBuff = defenceBuff;
        DamageBuff = damageBuff;
        HealthBuff = healthBuff;
        BonusImage = bonusImage;
        Name = name;
        Chance = chance;
    }
}
