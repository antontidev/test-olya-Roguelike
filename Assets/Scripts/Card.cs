using System;
using Core.Pools.Base;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour,
                    IPoolReset {
    public CardStats CardStat;

    public TextMeshProUGUI title;
    public Image CardImage;
    public TextMeshProUGUI description;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healText;
    
    public GameObject damage;
    public GameObject heal;
    public GameObject defense;

    public CanvasGroup CanvasGroup;

    public void ShowCard(CardStats cardStat)
    {
        CardStat = cardStat;
        
        if (CardStat.Damage == 0)
            damage.SetActive(false);
        else
        {
            damage.SetActive(true);
            damageText.text = CardStat.Damage.ToString();
        }
        if (CardStat.Defense == 0)
            defense.SetActive(false);
        else
        {
            defense.SetActive(true);
            defenceText.text = CardStat.Defense.ToString();
        }
        if (CardStat.Heal == 0)
            heal.SetActive(false);
        else
        {
            heal.SetActive(true);
            healText.text = CardStat.Heal.ToString();
        }

        title.text = CardStat.Name;
        description.text = CardStat.CountAddCards switch
        {
            0 => CardStat.Description,
            1 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карту",
            2 or 3 or 4 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карты",
            5 or 6 or 7 or 8 or 9 => CardStat.Description + "Возьмите\n" + CardStat.CountAddCards + " карт",
            _ => description.text
        };
    }

    public void Reset() {
        CanvasGroup.blocksRaycasts = true;
    }

    public void ChangeCardImage(Sprite cardImage) {
        CardImage.sprite = cardImage;
    }
}
