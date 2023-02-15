using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class ShopItemView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _cardLabel;

        [SerializeField]
        private TMP_Text _buttonLabel;

        [SerializeField]
        private Image _image;

        public Button button;

        private int _defence;

        private int _damage;

        private int _health;

        private BonusStats _bonusStats;
        
        public void Initialize(BonusStats stats, int index, Action<int> callback = null)
        {
            _cardLabel.text = stats.Name;
            _image = stats.BonusImage;
            _defence = stats.DefenceBuff;
            _damage = stats.DamageBuff;
            _health = stats.HealthBuff;
            _bonusStats = stats;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => callback?.Invoke(index));
        }
        public void SetName(string cardLabel)
        {
            _cardLabel.text = cardLabel;
        }

        public void SetButtonLabel(string buttonLabel)
        {
            _buttonLabel.text = buttonLabel;
        }

        public void SetImage(Image image)
        {
            _image = image;
        }
    }
}
