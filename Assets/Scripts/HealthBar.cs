using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI countOfHealth;
    public GameObject logoHealth;
    public GameObject logoDefense;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        
        SetHealth(maxHealth);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
        
        countOfHealth.text = slider.value + "/" + slider.maxValue;
    }

    public void SetDefense(int defense)
    {
        if (defense == 0)
        {
            logoDefense.SetActive(false);
            logoHealth.SetActive(true);
            slider.fillRect.GetComponent<Image>().color = new Color(0.8301887f, 0.1206123f, 0.1206123f);
        }
        else
        {
            logoDefense.SetActive(true);
            logoHealth.SetActive(false);
            slider.fillRect.GetComponent<Image>().color = new Color(0f, 0.5882353f, 0.9137256f);
            logoDefense.GetComponentInChildren<TextMeshProUGUI>().text = defense.ToString();
        }
    }
}