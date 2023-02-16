using DefaultNamespace;
using Services;
using UnityEngine;
using Views;

public abstract class Character : MonoBehaviour
{
    public Canvas StatusCanvas;

    protected CharacterStats _characterStats;

    protected int Health;
    protected int Defence;
    
    public bool Died;

    public Transform VisualSpawnTransform;

    public Animator Animator;
    public CharacterStatusView CharacterStatusView;
    public CardsHand CardsHand;
    
    public BattleController BattleController;
    public abstract void Initialize(BattleController battleController, int initialHand);
    
    public int GetCountCardsInHand() {
        return CardsHand.GetCountCardsInHand();
    }

    public void AddCardsToHand(int countToAdd) {
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
    
    public void AddHealth(int addHealth)
    {
        SetHealth(Health+addHealth);
    }
    private void ReduceHealth(int reduceHealth)
    {
        SetHealth(Health-reduceHealth);
    }
    private void SetHealth(int health)
    {
        Health = (health>_characterStats.GetMaxHealth()?_characterStats.GetMaxHealth():health);
        
        CharacterStatusView.SetHealth(Health);

        if (Health <= 0) IsDie();
    }

    
    public void AddDefense(int addDefense)
    {
        SetDefense(Defence+addDefense);
    }
    private void ReduceDefense(int reduceDefense)
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
