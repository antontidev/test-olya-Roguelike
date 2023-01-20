using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int MaxHealth;
    protected int Health;
    protected int Defense;
    protected int Damage;

    public HealthBar healthBar;
    public GameObject spritePrefab;
    public TextMeshProUGUI cardMove;
    
    public GameController gameController;
    public CardController cardController;

    public abstract void Start();
    
    public void GetDamage(int damage) 
    {
        if (Defense == 0)
        {
            cardMove.text = "-" + damage + " здоровья";
            SetHealth(Health-damage);
        }
        else if (Defense >= damage)
            SetDefense(Defense-damage);
        else if (Defense < damage) 
        {
            cardMove.text = "-" + (damage-Defense) + " здоровья";
            SetHealth(Health-damage+Defense);
            SetDefense(0);
        }
        cardMove.text = "";
    }

    protected void SetHealth(int health)
    {
        Health = (health>MaxHealth?MaxHealth:health);
        
        healthBar.SetHealth(Health);
        
        if (Health <= 0) IsDie();
    }
    protected void SetDefense(int defense)
    {
        Defense = defense;
        healthBar.SetDefense(Defense);
    }

    public void SetDamage(int damage)
    {
        Damage = damage;
    }

    public abstract void CardMove(Card card);
    protected abstract void IsDie();
}
