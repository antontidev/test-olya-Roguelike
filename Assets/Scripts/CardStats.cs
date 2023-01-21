using System;

[Serializable]
public struct CardStats {
    public string Guid;
    public string Name;
    public string Description;
    public string LogoPrefab;

    public int Heal;
    public int Defense;
    public int Damage;
    public int CountAddCards;

    public CardStats(int heal, int damage, int defense, int countAddCards, string name, string description,
        string logoPrefab) {
        Guid = System.Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        LogoPrefab = logoPrefab;
        Heal = heal;
        Damage = damage;
        Defense = defense;
        CountAddCards = countAddCards;
    }
}
