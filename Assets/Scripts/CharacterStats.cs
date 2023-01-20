public struct CharacterStats
{
    public readonly int MaxHealth;
    public readonly int Defense;
    public readonly int Damage;

    public readonly string SpriteLink;
    
    public CharacterStats(int maxHealth, int damage, int defense, string spriteLink)
    {
        MaxHealth = maxHealth;
        Damage = damage;
        Defense = defense;
        SpriteLink = spriteLink;
    }
}