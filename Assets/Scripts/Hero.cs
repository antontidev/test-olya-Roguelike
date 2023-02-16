using DG.Tweening;
using Services;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : Character {

    public override void Start()
    {
        _characterStats = GameController.Instance.CharacterStats;
        
        var obj = Instantiate(Resources.Load(_characterStats.SpriteLink), VisualSpawnTransform, false);

        // obj.transform.localPosition = Vector3.zero;
        // Animator = (Animator)Resources.Load(_characterStats.AnimatorLink);
        Animator = obj.GameObject().GetComponent<Animator>();

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
