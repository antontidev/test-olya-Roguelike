using DG.Tweening;
using UnityEngine;

public class Hero : Character {

    public override void Start()
    {
        _characterStats = HeroMap.Heroes[0];
        
        Instantiate(Resources.Load(_characterStats.SpriteLink), VisualSpawnTransform, false);

        // obj.transform.localPosition = Vector3.zero;
        Animator = (Animator)Resources.Load(_characterStats.AnimatorLink);

        Health = _characterStats.GetMaxHealth();
        CharacterStatusView.SetMaxHealth(Health);

        SetDefense(_characterStats.GetDefence());
    }

    public override void MakeDamage(int cardDamage)
    {
        PlayAnimation(Animation.Attack);
        BattleController.enemy.GetDamage(_characterStats.GetDamage() * cardDamage);
    }

    protected override void IsDie()
    {
        Died = true;
        PlayAnimation(Animation.Death);
        BattleController.GameLoss();
    }
}
