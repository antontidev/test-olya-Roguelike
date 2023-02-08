using System;
using DefaultNamespace;
using DG.Tweening;
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
    // public TextMeshProUGUI cardMove;
    
    public GameController gameController;
    public CardController cardController;

    public void Initialize(GameController gameController,
        CardController cardController, int initialHand)
    {
        this.gameController = gameController;
        this.cardController = cardController;
        CardsHand.Initialize(this.cardController, initialHand);
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
        if (damage < Defence)
            ReduceDefense(damage);
        else
        {
            PlayAnimation(Animation.Damage);
            ReduceHealth(damage-Defence);
            SetDefense(0);
        }
    }
    public abstract void MakeDamage(int cardDamage);
    
    public void SetDamage(int damage)
    {
        Damage = damage;
    }
    
    
    public void AddHealth(int addHealth)
    {
        SetHealth(Health+addHealth);
    }
    public void ReduceHealth(int reduceHealth)
    {
        SetHealth(Health-reduceHealth);
    }
    protected void SetHealth(int health)
    {
        Health = (health>MaxHealth?MaxHealth:health);
        
        CharacterStatusView.SetHealth(Health);

        if (Health <= 0) IsDie();
    }

    
    public void AddDefense(int addDefense)
    {
        SetDefense(Defence+addDefense);
    }
    public void ReduceDefense(int reduceDefense)
    {
        SetDefense(Defence-reduceDefense);
    }
    protected void SetDefense(int defense)
    {
        Defence = (defense<0?0:defense);
        CharacterStatusView.SetDefense(Defence);
    }


    protected abstract void IsDie();

    protected void PlayAnimation(Animation animation)
    {
        switch (animation)
        {
            case Animation.Idle:
                Animator.SetTrigger("Idle");
                break;
            case Animation.Attack:
                Animator.SetTrigger("Attack");
                break;
            case Animation.Damage:
                Animator.SetTrigger("Damage");
                break;
            case Animation.Death:
                Animator.SetTrigger("Death");
                break;
            default:
                break;
        }
    }
}
