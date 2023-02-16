using Configs.Enemies;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public EnemiesConfig EnemiesConfig;

    public override void Start()
    {
        EnemiesConfig.Initialize();
        _characterStats = RandomSelection();
        
        var obj = Instantiate(Resources.Load(_characterStats.SpriteLink), VisualSpawnTransform, false);
        
        // Animator = (Animator)Resources.Load(_characterStats.AnimatorLink);
        Animator = obj.GameObject().GetComponent<Animator>();
        
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
        return EnemiesConfig.GetRandomEnemy();
    }
}
