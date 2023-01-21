using TMPro;
using UnityEngine;

public class Hero : Character
{
    public override void Start()
    {
        Instantiate(Resources.Load(HeroMap.Heroes[0].SpriteLink), transform, false);

        MaxHealth = Health = HeroMap.Heroes[0].MaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);

        SetDamage(HeroMap.Heroes[0].Damage);
        SetDefense(HeroMap.Heroes[0].Defense);

        cardController.SetCardsInHandHero(6);
    }

    public override void CardMove(CardView cardView)
    {
        if (cardView.CardStat.Damage != 0)
        {
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
            cardMove.text = "";
        }
        if (cardView.CardStat.CountAddCards != 0) 
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " карты";
            cardController.SetCardsInHandHero(cardView.CardStat.CountAddCards);
            cardMove.text = "";
        }
    }
    
    protected override void IsDie()
    {
        gameController.EndGame();
    }
}
