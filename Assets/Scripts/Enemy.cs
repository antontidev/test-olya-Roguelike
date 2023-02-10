using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public override void Start()
    {
        var characterStats = RandomSelection();
        
        var obj = (GameObject)Instantiate(Resources.Load(characterStats.SpriteLink), VisualSpawnTransform, false);
        Animator = obj.GetComponent<Animator>();
        
        MaxHealth = Health = characterStats.InitialMaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);
        
        Damage = characterStats.InitialDamage;
        SetDefense(characterStats.InitialDefense);
    }
    
    public override void MakeDamage(int cardDamage)
    {
        PlayAnimation(Animation.Attack);
        BattleController.hero.GetDamage(Damage * cardDamage);
    }

    protected override void IsDie()
    {
        Died = true;
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
            {
                PlayAnimation(Animation.Death);
            })
            .AppendInterval(3)
            .AppendCallback(() =>
            {
                _destroyEnemy = gameObject;
                BattleController.enemy = null;
                Destroy(_destroyEnemy);
                BattleController.NextWave();
            });
    }
    
    private CharacterStats RandomSelection()
    {
        return EnemyMap.Enemies[_random.Next(EnemyMap.Enemies.Count)];
    }
}
