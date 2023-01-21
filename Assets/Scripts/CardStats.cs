using UnityEngine;

public struct CardStats
{
    public readonly string Name;
    public readonly string Description;
    
    public readonly int Heal;
    public readonly int Defense;
    public readonly int Damage;
    public readonly int CountAddCards;

    public CardStats(int heal, int damage, int defense, int countAddCards, string name, string description,
        string logoPrefab)
    {
        Name = name;
        Description = description;
        Heal = heal;
        Damage = damage;
        Defense = defense;
        CountAddCards = countAddCards;
    }
}
