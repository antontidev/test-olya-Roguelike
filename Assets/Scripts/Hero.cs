using DG.Tweening;
using UnityEngine;

public class Hero : Character {

    public override void Start()
    {
        var obj = (GameObject)Instantiate(Resources.Load(HeroMap.Heroes[0].SpriteLink), VisualSpawnTransform, false);

        obj.transform.localPosition = Vector3.zero;
        Animator = obj.GetComponent<Animator>();
        
        MaxHealth = Health = HeroMap.Heroes[0].InitialMaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);

        SetDamage(HeroMap.Heroes[0].InitialDamage);
        SetDefense(HeroMap.Heroes[0].InitialDefense);
    }

    public override void MakeDamage(int cardDamage)
    {
        PlayAnimation(Animation.Attack);
        BattleController.enemy.GetDamage(Damage * cardDamage);
    }

    protected override void IsDie()
    {
        Died = true;
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
            {
                PlayAnimation(Animation.Death);
            })
            .AppendCallback(BattleController.GameLoss);
    }
}
