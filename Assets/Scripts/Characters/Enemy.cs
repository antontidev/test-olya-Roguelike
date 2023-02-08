using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Characters
{
    public class Enemy : Character
    {
        private readonly System.Random _random = new();
    
        private GameObject _destroyEnemy;
    
        public static bool EnemyIsDie;
    
        public override void Start()
        {
            var characterStats = RandomSelection();
            
            var obj = (GameObject)Instantiate(Resources.Load(characterStats.SpriteLink), VisualSpawnTransform, false);
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
                GameController.Hero.GetDamage(Damage * cardView.CardStat.Damage);
            }
            if (cardView.CardStat.Heal != 0)
            {
                TextCardMove.text = "+" + cardView.CardStat.Heal + " здоровья";
                SetHealth(Health + cardView.CardStat.Heal);
                TextCardMove.text = "";
            }
            if (cardView.CardStat.Defense != 0)
            {
                TextCardMove.text = "+" + cardView.CardStat.Heal + " защиты";
                SetDefense(Defence + cardView.CardStat.Defense);
                Animator.SetTrigger("Defence");
                TextCardMove.text = "";
            }
            if (cardView.CardStat.CountAddCards != 0)
            {
                TextCardMove.text = "+" + cardView.CardStat.Heal + " карты";
                CardsHand.AddCardsToHand(cardView.CardStat.CountAddCards);
                TextCardMove.text = "";
            }
        }
    
        protected override void IsDie()
        {
            EnemyIsDie = true;
            _destroyEnemy = gameObject;
            GameController.Enemy = null;
            Destroy(_destroyEnemy);
            GameController.NextWave();
        }
        
        private CharacterStats RandomSelection()
        {
            return EnemyMap.Enemies[_random.Next(EnemyMap.Enemies.Count)];
        }
    }
}

