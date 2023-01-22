using System;
using DefaultNamespace;
using Services;
using TMPro;
using UnityEngine;
using Views;

public abstract class Character : MonoBehaviour
{
    public Canvas StatusCanvas;

    protected int MaxHealth;
    protected int Health;
    protected int Defence;
    protected int Damage;

    public Transform VisualSpawnTransform;

    public Animator Animator;
    public CharacterStatusView CharacterStatusView;
    public CardsHand CardsHand;
    public TextMeshProUGUI cardMove;
    
    public GameController gameController;
    public CardController cardController;

    public void Initialize(int initialHand) {
        CardsHand.Initialize(cardController, initialHand);
        StatusCanvas.worldCamera = Camera.main;
    }

    public int GetHandCount() {
        return CardsHand.GetHandCount();
    }

    public void SetCardsInHand(int countToAdd) {
        CardsHand.AddCardsToHand(countToAdd);
    }

    public CardStats GetAndRemoveCardFromHand(int index) {
        return CardsHand.GetAndRemove(index);
    }

    public abstract void Start();
    
    public void GetDamage(int damage) 
    {
        Animator.SetTrigger("Damage");
        if (Defence == 0)
        {
            cardMove.text = "-" + damage + " здоровья";
            SetHealth(Health-damage);
        }
        else if (Defence >= damage)
            SetDefense(Defence-damage);
        else if (Defence < damage) 
        {
            cardMove.text = "-" + (damage-Defence) + " здоровья";
            SetHealth(Health-damage+Defence);
            SetDefense(0);
        }
        cardMove.text = "";
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

    public abstract void CardMove(CardView cardView);
    protected abstract void IsDie();
}
