using System.Collections.Generic;
using Configs;
using Factory;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services {
    /// <summary>
    /// Incapsulates logic for card view creation
    /// </summary>
    public class CardController : MonoBehaviour
    {
        private static readonly System.Random Random = new();

        public CardsFactoryConfig cardsFactoryConfig;
        public CardsImagesConfig cardsImagesConfig;
        public CardsConfig cardsConfig;

        public Transform cardsRootInactive;
        public Transform cardsRoot;
        public CanvasGroup cardsRootCanvasGroup;
        
        private CardsFactory _cardsFactory;

        public void Initialize() {
            _cardsFactory = new CardsFactory(cardsFactoryConfig, cardsRoot);
            _cardsFactory.SetInactiveParent(cardsRootInactive);
            _cardsFactory.Initialize();
        }

        public void ReleaseCardView(CardView cardView) {
            _cardsFactory.Release(cardView);
        }

        public CardView GetAndFillCardView(CardStats cardData) {
            var card = _cardsFactory.GetCardView();
            
            card.ShowCard(cardData);
            
            var imageName = cardData.LogoPrefab;
            var cardImage = cardsImagesConfig.Config[imageName];
            card.ChangeCardImage(cardImage);

            return card;
        }

        public void AddCardsToHand(int countAddCards, List<CardStats> cards)
        {
            GetRandomCardsData(countAddCards, cards);
        }

        // TODO add service to randomize on chances
        private void GetRandomCardsData(int count, List<CardStats> list) {
            var cardsCount = cardsConfig.GetCardsCount();
            for (int i = 0; i < count; i++) {
                var randomIndex = Random.Next(cardsCount);
                var card = cardsConfig.Config[randomIndex];
                list.Add(card);
            }
        }
    }
}
