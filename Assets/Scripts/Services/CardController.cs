using System.Collections.Generic;
using Configs;
using Factory;
using UnityEngine;

namespace Services {
    /// <summary>
    /// Incapsulates logic for card view creation
    /// </summary>
    public class CardController : MonoBehaviour
    {
        public CardsFactoryConfig CardsFactoryConfig;
        public CardsImagesConfig CardsImagesConfig;
        public CardsConfig CardsConfig;

        public Transform CardsRootInactive;
        public Transform CardsRoot;
        public CanvasGroup CardsRootCanvasGroup;
        
        private CardsFactory _cardsFactory;

        public void Initialize() {
            CardsConfig.Initialize();
            _cardsFactory = new CardsFactory(CardsFactoryConfig, CardsRoot);
            _cardsFactory.SetInactiveParent(CardsRootInactive);
            _cardsFactory.Initialize();
        }

        public void ReleaseCardView(CardView cardView) {
            _cardsFactory.Release(cardView);
        }

        public CardView GetAndFillCardView(CardStats cardData) {
            var card = _cardsFactory.GetCardView();
            
            card.ShowCard(cardData);
            
            var imageName = cardData.LogoPrefab;
            var cardImage = CardsImagesConfig.Config[imageName];
            card.ChangeCardImage(cardImage);

            return card;
        }

        public void AddCardsToHand(int countAddCards, List<CardStats> cards)
        {
            GetRandomCardsData(countAddCards, cards);
        }

        private void GetRandomCardsData(int count, List<CardStats> list)
        {
            for (var i = 0; i < count; i++)
            {
                var card = CardsConfig.GetRandomCardStats();
                list.Add(card);
            }
        }
    }
}
