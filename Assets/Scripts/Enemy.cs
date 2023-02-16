using Configs.Enemies;
using Services;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public EnemiesConfig EnemiesConfig;

    public DropZone DropZone;

    public override void Initialize(BattleController battleController, int initialHand)
    {
        Died = false;
        
        BattleController = battleController;
        
        DropZone.Initialize(this);
        
        CardsHand.Initialize(BattleController.CardController, initialHand);
        
        StatusCanvas.worldCamera = Camera.main;
    }

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
    
    // public void MakeDamage(int cardDamage)
    // {
    //     PlayAnimation(Animation.Attack);
    //     BattleController.Hero.GetDamage(_characterStats.GetDamage() * cardDamage);
    // }

    protected override void IsDie()
    {
        Died = true;
        PlayAnimation(Animation.Death);
        BattleController.Enemy.Remove(this);
        Destroy(gameObject);
    }
    
    private CharacterStats RandomSelection()
    {
        return EnemiesConfig.GetRandomEnemy();
    }
}
