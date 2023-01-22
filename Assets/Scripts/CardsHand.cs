using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class CardsHand : MonoBehaviour {
        private List<CardStats> _cardsInHand;
        private CardController _cardController;

        private Action _onHandChange;

        public void Initialize(CardController cardController, int initialHand) {
            _cardController = cardController;
            _cardsInHand = new List<CardStats>();
            
            AddCardsToHand(initialHand);
        }

        public int GetHandCount() {
            return _cardsInHand.Count;
        }

        public CardStats GetCardData(int index) {
            return _cardsInHand[index];
        }

        public void SubscribeOnHandChange(Action callback) {
            _onHandChange += callback;
        }

        public void UnsubscribeFromHandChange(Action callback) {
            _onHandChange -= callback;
        }
        
        public void AddCardsToHand(int countToAdd) {
            _cardController.AddCardsToHand(countToAdd, _cardsInHand);
            
            _onHandChange?.Invoke();
        }

        public CardStats GetAndRemove(int index) {
            var stat = _cardsInHand[index];

            _cardsInHand.RemoveAt(index);

            _onHandChange?.Invoke();

            return stat;
        }
    }
}