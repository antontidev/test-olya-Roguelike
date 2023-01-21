using System;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class CardsHand : MonoBehaviour {
        public List<CardStats> CardsInHand;
        private CardController _cardController;

        private Action _onHandChange;

        public void Initialize(CardController cardController, int initialHand) {
            _cardController = cardController;
            CardsInHand = new List<CardStats>();
            
            SetCardsInHand(initialHand);
        }

        public void SubscribeOnHandChange(Action callback) {
            _onHandChange += callback;
        }

        public void UnsubscribeFromHandChange(Action callback) {
            _onHandChange -= callback;
        }
        
        public void SetCardsInHand(int countToAdd) {
            _cardController.SetCardsInHand(countToAdd, CardsInHand);
            
            _onHandChange?.Invoke();
        }

        public CardStats GetAndRemove(int index) {
            var stat = CardsInHand[index];

            CardsInHand.RemoveAt(index);

            _onHandChange?.Invoke();

            return stat;
        }

        public void Remove(CardStats stats) {
            CardsInHand.RemoveAll(item => item.Guid == stats.Guid);
            
            _onHandChange?.Invoke();
        }
    }
}