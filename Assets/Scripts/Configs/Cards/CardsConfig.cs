using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable StringLiteralTypo

namespace Configs.Cards {
    [CreateAssetMenu(menuName = "Configs/Cards/Cards config", fileName = "CardsConfig")]
    public class CardsConfig : ScriptableObject {
        public List<CardStats> Config;
        
        private List<CardStats> _cardList;
        private System.Random _random;
        
        public void Initialize()
        {
            _random = new System.Random();
            _cardList = new();

            CorrectChance();
        
            for (int j = 0; j < Config.Count; j++)
            for (int i = 0; i < Config[j].Chance * 10; i++)
                _cardList.Add(Config[j]);
            
            //лишняя проверочка
            if (_cardList.Count != 1000)
                throw new ArgumentException("Карт не 1000");
        }

        public int GetCardsCount() {
            return Config.Count;
        }

        public CardStats GetRandomCardStats()
        {
            return _cardList[_random.Next(_cardList.Count)];
        }

        private void CorrectChance()
        {
            var chance = 0f;
            for (int i = 0; i < Config.Count; i++)
                chance += Config[i].Chance;
            if (chance != 100f)
                throw new ArgumentException("Некорректная вероятность выпадения карт");
        }
    }
}