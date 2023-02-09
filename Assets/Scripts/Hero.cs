using DG.Tweening;
using UnityEngine;

public class Hero : Character {

    public override void Start()
    {
        var obj = (GameObject)Instantiate(Resources.Load(HeroMap.Heroes[0].SpriteLink), VisualSpawnTransform, false);

        obj.transform.localPosition = Vector3.zero;
        Animator = obj.GetComponent<Animator>();
        
        MaxHealth = Health = HeroMap.Heroes[0].MaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);

        SetDamage(HeroMap.Heroes[0].Damage);
        SetDefense(HeroMap.Heroes[0].Defense);
    }

    public override void MakeDamage(int cardDamage)
    {
        PlayAnimation(Animation.Attack);
        gameController.enemy.GetDamage(Damage * cardDamage);
    }

    protected override void IsDie()
    {
        Died = true;
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
            {
                PlayAnimation(Animation.Death);
            })
            .AppendInterval(5);
    }
}
