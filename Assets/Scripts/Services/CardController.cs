﻿using System.Collections.Generic;
using Configs;
using Factory;
using UnityEngine;

namespace Services {
    public class CardController : MonoBehaviour
    {
        private static readonly System.Random Random = new();

        public CardsFactoryConfig CardsFactoryConfig;

        private CardsFactory _cardsFactory;

        private void Awake() {
            _cardsFactory = new CardsFactory(CardsFactoryConfig, transform);
            _cardsFactory.Initialize();
        }

        public Card GetCardView() {
            return _cardsFactory.GetCard();
        }

        public void ReleaseCardView(Card card) {
            _cardsFactory.Release(card);
        }

        public void SetCardsInHandHero(int countAddCards) {
            var cardsData = GetRandomCardsData(countAddCards);
            for (var i = 0; i < countAddCards; i++) {
                var card = _cardsFactory.GetCard();
                var cardData = cardsData[i];
                
                card.ShowCard(cardData);
            }
        }

        public void SetCardsInHandEnemy(int countAddCards, List<CardStats> cards)
        {
            GetRandomCardsData(countAddCards, cards);
        }
    
        private List<CardStats> GetRandomCardsData(int count) {
            var list = new List<CardStats>(count);

            for (int i = 0; i < count; i++) {
                var card = CardMap.Cards[Random.Next(CardMap.Cards.Count)];
                list.Add(card);
            }
            return list;
        }

        private void GetRandomCardsData(int count, List<CardStats> list) {
            for (int i = 0; i < count; i++) {
                var card = CardMap.Cards[Random.Next(CardMap.Cards.Count)];
                list.Add(card);
            }
        }
    }
}
