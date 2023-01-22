using UnityEngine;

public class Hero : Character {
    public override void Start() {
        var obj = (GameObject)Instantiate(Resources.Load(HeroMap.Heroes[0].SpriteLink), VisualSpawnTransform, false);

        obj.transform.localPosition = Vector3.zero;
        Animator = obj.GetComponent<Animator>();
        
        MaxHealth = Health = HeroMap.Heroes[0].MaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);

        SetDamage(HeroMap.Heroes[0].Damage);
        SetDefense(HeroMap.Heroes[0].Defense);
    }

    public override void CardMove(CardView cardView)
    {
        if (cardView.CardStat.Damage != 0)
        {
            Animator.SetTrigger("Attack");
            gameController.enemy.GetDamage(Damage * cardView.CardStat.Damage);
        }
        if (cardView.CardStat.Heal != 0)
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " здоровья";
            SetHealth(Health + cardView.CardStat.Heal);
            cardMove.text = "";
        }
        if (cardView.CardStat.Defense != 0)
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " защиты";
            SetDefense(Defence + cardView.CardStat.Defense);
            Animator.SetTrigger("Defence");
            cardMove.text = "";
        }
        if (cardView.CardStat.CountAddCards != 0) 
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " карты";
            CardsHand.AddCardsToHand(cardView.CardStat.CountAddCards);
            cardMove.text = "";
        }
    }
    
    protected override void IsDie()
    {
        gameController.EndGame();
    }
}
