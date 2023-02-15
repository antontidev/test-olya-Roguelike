using Configs.Bonus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class ItemManager : MonoBehaviour
    {
        public int countCards;

        public BonusConfig BonusConfig;

        public ShopItemView BonusPrefab;

        private List<BonusStats> _currentCards;

        [HideInInspector]
        public BonusStats pickedBonus;

        private Action _onBonusPicked;
        private void Awake()
        {
            _currentCards = new List<BonusStats>();
            BonusConfig.Initialize();

            for (int i = 0; i < countCards; i++)
            {
                ShopItemView spawnedItem = Instantiate(BonusPrefab);
                spawnedItem.transform.SetParent(transform, false);

                var randomBonus = BonusConfig.GetRandomBonusItem();

                _currentCards.Add(randomBonus);

                spawnedItem.Initialize(randomBonus, i, OnBonusPicked);
            }
        }

        private void OnBonusPicked(int index)
        {
            pickedBonus = _currentCards[index];

            _currentCards.Clear();

            _onBonusPicked?.Invoke();
            
        }

        public void SubscribeOnBonusPicked(Action callback)
        {
            _onBonusPicked += callback;
        }

        public void UnSubscribeOnBonusPicked(Action callback)
        {
            _onBonusPicked-= callback;
        }
    }
}
