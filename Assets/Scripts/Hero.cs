using DG.Tweening;
using Services;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : Character {

    public override void Start()
    {
        _characterStats = GameController.Instance.CharacterStats;
        
        var obj = Instantiate(Resources.Load(_characterStats.SpriteLink), VisualSpawnTransform, false);

        Animator = obj.GameObject().GetComponent<Animator>();

        Health = _characterStats.GetMaxHealth();
        CharacterStatusView.SetMaxHealth(Health);

        SetDefense(_characterStats.GetDefence());
    }

    public override void Initialize(BattleController battleController, int initialHand)
    {
        Died = false;
        
        BattleController = battleController;
        
        CardsHand.Initialize(BattleController.CardController, initialHand);
        
        StatusCanvas.worldCamera = Camera.main;
    }
    
    public void MakeDamage(int cardDamage, Enemy enemy)
    {
        PlayAnimation(Animation.Attack);
        enemy.GetDamage(_characterStats.GetDamage() * cardDamage);
    }

    protected override void IsDie()
    {
        Died = true;
        PlayAnimation(Animation.Death);
        BattleController.GameLoss();
    }
}
