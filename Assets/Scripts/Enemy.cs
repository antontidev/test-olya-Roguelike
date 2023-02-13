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
        _characterStats = RandomSelection();
        
        var obj = (GameObject)Instantiate(Resources.Load(_characterStats.SpriteLink), VisualSpawnTransform, false);
        
        Animator = (Animator)Resources.Load(_characterStats.AnimatorLink);
        
        Health = _characterStats.GetMaxHealth();
        CharacterStatusView.SetMaxHealth(Health);
        
        SetDefense(_characterStats.GetDefence());
    }
    
    public override void MakeDamage(int cardDamage)
    {
        PlayAnimation(Animation.Attack);
        BattleController.hero.GetDamage(_characterStats.GetDamage() * cardDamage);
    }

    protected override void IsDie()
    {
        Died = true;
        PlayAnimation(Animation.Death);
        _destroyEnemy = gameObject;
        BattleController.enemy = null;
        Destroy(_destroyEnemy);
        BattleController.NextWave();
    }
    
    private CharacterStats RandomSelection()
    {
        return EnemyMap.Enemies[_random.Next(EnemyMap.Enemies.Count)];
    }
}
