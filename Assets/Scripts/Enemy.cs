using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public List<CardStats> CardsInHand;
    public static bool EnemyIsDie;

    public override void Start()
    {
        var characterStats = RandomSelection();
        
        Instantiate(Resources.Load(characterStats.SpriteLink), transform, false);
        
        MaxHealth = Health = characterStats.MaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);
        
        Damage = characterStats.Damage;
        SetDefense(characterStats.Defense);

        CardsInHand = new List<CardStats>();
        cardController.SetCardsInHandEnemy(6, CardsInHand);
    }

    public override void CardMove(CardView cardView)
    {
        if (cardView.CardStat.Damage != 0)
        {
            gameController.hero.GetDamage(Damage * cardView.CardStat.Damage);
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
            cardController.SetCardsInHandEnemy(cardView.CardStat.CountAddCards, CardsInHand);
            cardMove.text = "";
        }
    }

    protected override void IsDie()
    {
        EnemyIsDie = true;
        _destroyEnemy = gameObject;
        gameController.enemy = null;
        Destroy(_destroyEnemy);
        gameController.NextWave();
    }
    
    private CharacterStats RandomSelection()
    {
        return EnemyMap.Enemies[_random.Next(EnemyMap.Enemies.Count)];
    }
}
