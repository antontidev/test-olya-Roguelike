public struct CharacterStats
{
    public readonly int InitialMaxHealth;
    public int PermanentBuffMaxHealth;
    public int TemporaryBuffMaxHealth;
    
    public readonly int InitialDefense;
    public int PermanentBuffDefense;
    public int TemporaryBuffDefense;
    
    public readonly int InitialDamage;
    public int PermanentBuffDamage;
    public int TemporaryBuffDamage;
    
    public string SpriteLink;
    
    public CharacterStats(int initialMaxHealth, int initialDamage, int initialDefense, string spriteLink)
    {
        InitialMaxHealth = initialMaxHealth;
        InitialDamage = initialDamage;
        InitialDefense = initialDefense;
        SpriteLink = spriteLink;
        
        PermanentBuffMaxHealth = 0;
        TemporaryBuffMaxHealth = 0;
        
        PermanentBuffDefense = 0;
        TemporaryBuffDefense = 0;
        
        PermanentBuffDamage = 0;
        TemporaryBuffDamage = 0;
    }

    public int GetMaxHealth()
    {
        return InitialMaxHealth + PermanentBuffMaxHealth + TemporaryBuffMaxHealth;
    }

    public int GetDamage()
    {
        return InitialDamage + PermanentBuffDamage + TemporaryBuffDamage;
    }

    public int GetDefence()
    {
        return InitialDefense + PermanentBuffDefense + TemporaryBuffDefense;
    }
}