using System;
using Services;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardStats CardStat;

    public TextMeshProUGUI title;
    public GameObject logoArea;
    public TextMeshProUGUI description;
    
    public GameObject damage;
    public GameObject heal;
    public GameObject defense;

    public void ShowCard(CardStats cardStat)
    {
        CardStat = cardStat;
        
        if (CardStat.Damage == 0)
            damage.SetActive(false);
        else
        {
            damage.SetActive(true);
            damage.GetComponentInChildren<TextMeshProUGUI>().text = CardStat.Damage.ToString();
        }
        if (CardStat.Defense == 0)
            defense.SetActive(false);
        else
        {
            defense.SetActive(true);
            defense.GetComponentInChildren<TextMeshProUGUI>().text = CardStat.Defense.ToString();
        }
        if (CardStat.Heal == 0)
            heal.SetActive(false);
        else
        {
            heal.SetActive(true);
            heal.GetComponentInChildren<TextMeshProUGUI>().text = CardStat.Heal.ToString();
        }

        title.text = CardStat.Name;
        Instantiate(CardStat.LogoPrefab, logoArea.transform, false);
        description.text = CardStat.CountAddCards switch
        {
            0 => CardStat.Description,
            1 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карту",
            2 or 3 or 4 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карты",
            5 or 6 or 7 or 8 or 9 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карт",
            _ => description.text
        };
    }
}
