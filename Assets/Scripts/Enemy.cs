using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private readonly System.Random _random = new();

    private GameObject _destroyEnemy;

    public static bool EnemyIsDie;

    public override void Start()
    {
        var characterStats = RandomSelection();
        
        var obj = (GameObject)Instantiate(Resources.Load(characterStats.SpriteLink), transform, false);
        Animator = obj.GetComponent<Animator>();
        
        MaxHealth = Health = characterStats.MaxHealth;
        CharacterStatusView.SetMaxHealth(MaxHealth);
        
        Damage = characterStats.Damage;
        SetDefense(characterStats.Defense);
    }

    public override void CardMove(CardView cardView)
    {
        if (cardView.CardStat.Damage != 0)
        {
            Animator.SetTrigger("Attack");
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
            Animator.SetTrigger("Defence");
            cardMove.text = "";
        }
        if (cardView.CardStat.CountAddCards != 0)
        {
            cardMove.text = "+" + cardView.CardStat.Heal + " карты";
            CardsHand.SetCardsInHand(cardView.CardStat.CountAddCards);
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
