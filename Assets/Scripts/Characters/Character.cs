using DefaultNamespace;
using Services;
using TMPro;
using UnityEngine;
using Views;

namespace Characters
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField]
        private Canvas StatusCanvas;

        protected int MaxHealth;
        protected int Health;
        protected int Defence;
        protected int Damage;

        [SerializeField]
        protected Transform VisualSpawnTransform;

        protected Animator Animator;
        [SerializeField]
        protected CharacterStatusView CharacterStatusView;
        protected TextMeshProUGUI TextCardMove;
    
        protected CardsHand CardsHand;
    
        protected GameController GameController;
        protected CardController CardController;

        public void Initialize(CardController cardController, GameController gameController, int initialHand)
        {
            CardController = cardController;
            GameController = gameController;
            CardsHand.Initialize(CardController, initialHand);
            StatusCanvas.worldCamera = Camera.main;
        }

        public int GetHandCount() {
            return CardsHand.GetHandCount();
        }

        public void AddCardsToHand(int countToAdd) {
            CardsHand.AddCardsToHand(countToAdd);
        }

        public CardStats GetAndRemoveCardFromHand(int index) {
            return CardsHand.GetAndRemove(index);
        }

    
        public void GetDamage(int damage) 
        {
            if (damage > Defence)
            {
                Animator.SetTrigger("Damage");
                TextCardMove.text = "-" + (damage-Defence) + " здоровья";
                SetHealth(Health-damage+Defence);
            }
            else if (Defence > damage)
                TextCardMove.text = "-" + (Defence - damage) + " защиты";
            SetDefense(Defence > damage?Defence-damage:0);
            TextCardMove.text = "";
        }

        protected void SetHealth(int health)
        {
            Health = (health>MaxHealth?MaxHealth:health);
        
            CharacterStatusView.SetHealth(Health);
        
            if (Health <= 0) IsDie();
        }
        protected void SetDefense(int defence)
        {
            Defence = defence;
            CharacterStatusView.SetDefence(Defence);
        }

        public void SetDamage(int damage)
        {
            Damage = damage;
        }

        public abstract void Start();
        public abstract void CardMove(CardView cardView);
        protected abstract void IsDie();
    }
}
