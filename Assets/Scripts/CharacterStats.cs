using System;

[Serializable]
public struct CharacterStats
{
    public int InitialMaxHealth;
    public int PermanentBuffMaxHealth;
    public int TemporaryBuffMaxHealth;
    
    public int InitialDefense;
    public int PermanentBuffDefense;
    public int TemporaryBuffDefense;
    
    public int InitialDamage;
    public int PermanentBuffDamage;
    public int TemporaryBuffDamage;

    public string SpriteLink;
    public string AnimatorLink;
    
    public int GetMaxHealth()
    {
        return InitialMaxHealth + PermanentBuffMaxHealth + TemporaryBuffMaxHealth;
    }
    public int GetTemporaryBuffMaxHealth()
    {
        return TemporaryBuffMaxHealth;
    }
    public void ChangePermanentBuffMaxHealth(int changeMaxHealth)
    {
        PermanentBuffMaxHealth += changeMaxHealth;
    }
    public void ChangeTemporaryBuffMaxHealth(int changeMaxHealth)
    {
        TemporaryBuffMaxHealth += changeMaxHealth;
    }
    
    public int GetDamage()
    {
        return InitialDamage + PermanentBuffDamage + TemporaryBuffDamage;
    }
    public int GetTemporaryBuffDamage()
    {
        return TemporaryBuffDamage;
    }
    public void ChangePermanentBuffDamage(int changeDamage)
    {
        PermanentBuffDamage += changeDamage;
    }
    public void ChangeTemporaryBuffDamage(int changeDamage)
    {
        TemporaryBuffDamage += changeDamage;
    }
    
    public int GetDefence()
    {
        return InitialDefense + PermanentBuffDefense + TemporaryBuffDefense;
    }
}