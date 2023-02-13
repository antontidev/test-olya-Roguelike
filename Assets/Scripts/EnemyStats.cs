using System;

[Serializable]
public struct EnemyStats
{
    public CharacterStats CharacterStats;

    public float Chance;
    
    public EnemyStats(CharacterStats characterStats, float chance)
    {
        CharacterStats = characterStats;
        Chance = chance;
    }
}