using System.Collections.Generic;
using Configs;
using Factory;
using UnityEngine;

namespace Services {
    public class CardController : MonoBehaviour
    {
        private static readonly System.Random Random = new();

        public CardsFactoryConfig CardsFactoryConfig;
        public CardsImagesConfig CardsImagesConfig;

        public Transform CardsRoot;
        public CanvasGroup CardsRootCanvasGroup;
        
        private CardsFactory _cardsFactory;

        private void Awake() {
            _cardsFactory = new CardsFactory(CardsFactoryConfig, CardsRoot);
            _cardsFactory.Initialize();
        }

        public CardView GetCardView() {
            return _cardsFactory.GetCardView();
        }

        public void ReleaseCardView(CardView cardView) {
            _cardsFactory.Release(cardView);
        }

        public void SetCardsInHandHero(int countAddCards) {
            var cardsData = GetRandomCardsData(countAddCards);
            for (var i = 0; i < countAddCards; i++) {
                var cardData = cardsData[i];

                GetAndFillCardView(cardData);
            }
        }

        public CardView GetAndFillCardView(CardStats cardData) {
            var card = _cardsFactory.GetCardView();

            card.ShowCard(cardData);
            
            var imageName = cardData.LogoPrefab;
            var cardImage = CardsImagesConfig.Config[imageName];
            card.ChangeCardImage(cardImage);

            return card;
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
