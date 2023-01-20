using TMPro;
using UnityEngine;

public class Hero : Character
{
    public override void Start()
    {
        Instantiate(Resources.Load(HeroMap.Heroes[0].SpriteLink), transform, false);

        MaxHealth = Health = HeroMap.Heroes[0].MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        SetDamage(HeroMap.Heroes[0].Damage);
        SetDefense(HeroMap.Heroes[0].Defense);

        cardController.SetCardsInHandHero(6);
    }

    public override void CardMove(Card card)
    {
        if (card.CardStat.Damage != 0)
        {
            gameController.enemy.GetDamage(Damage * card.CardStat.Damage);
        }
        if (card.CardStat.Heal != 0)
        {
            cardMove.text = "+" + card.CardStat.Heal + " здоровья";
            SetHealth(Health + card.CardStat.Heal);
            cardMove.text = "";
        }
        if (card.CardStat.Defense != 0)
        {
            cardMove.text = "+" + card.CardStat.Heal + " защиты";
            SetDefense(Defense + card.CardStat.Defense);
            cardMove.text = "";
        }
        if (card.CardStat.CountAddCards != 0) 
        {
            cardMove.text = "+" + card.CardStat.Heal + " карты";
            cardController.SetCardsInHandHero(card.CardStat.CountAddCards);
            cardMove.text = "";
        }
    }
    
    protected override void IsDie()
    {
        gameController.EndGame();
    }
}
