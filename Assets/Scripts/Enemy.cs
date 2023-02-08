using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public static bool EnemyIsDie;

    public override void Start()
    {
        var characterStats = RandomSelection();
        
        var obj = (GameObject)Instantiate(Resources.Load(characterStats.SpriteLink), VisualSpawnTransform, false);
        Animator = obj.GetComponent<Animator>();
        
        MaxHealth = Health = characterStats.MaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);
        
        Damage = characterStats.Damage;
        SetDefense(characterStats.Defense);
    }
    
    public override void MakeDamage(int cardDamage)
    {
        PlayAnimation(Animation.Attack);
        gameController.hero.GetDamage(Damage * cardDamage);
    }

    protected override void IsDie()
    {
        PlayAnimation(Animation.Death);
        EnemyIsDie = true;
        _destroyEnemy = gameObject;
        gameController.enemy = null;
        Destroy(_destroyEnemy);
        gameController.NextWave();
    }
    
    private CharacterStats RandomSelection()
    {
        return EnemyMap.Enemies[_random.Next(EnemyMap.Enemies.Count)];
    }
}
