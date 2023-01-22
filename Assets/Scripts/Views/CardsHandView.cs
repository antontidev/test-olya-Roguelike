using System.Collections.Generic;
using DefaultNamespace;
using Services;
using UnityEngine;

namespace Views {
    public class CardsHandView : MonoBehaviour {
        private CardsHand _cardsHand;
        private CardController _cardController;

        private List<CardView> _activeViews;

        public void Initialize(CardsHand cardsHand,
            CardController cardController) {
            _activeViews = new List<CardView>();
            
            _cardsHand = cardsHand;
            _cardController = cardController;
            _cardsHand.SubscribeOnHandChange(OnHandChange);
        }

        public void ChangeHand(CardsHand hand) {
            _cardsHand = hand;
            
            OnHandChange();
        }

        private void OnHandChange() {
            foreach (var view in _activeViews) {
                _cardController.ReleaseCardView(view);
            }
            
            _activeViews.Clear();

            for (int i = 0; i < _cardsHand.GetHandCount(); i++) {
                var cardData = _cardsHand.GetCardData(i);
                var cardView = _cardController.GetAndFillCardView(cardData);
                cardView.CardIndex = i;
                
                _activeViews.Add(cardView);
            }
        }
    }
}