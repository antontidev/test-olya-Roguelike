using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class CardsHand : MonoBehaviour {
        private List<CardStats> _cardStatsInHand;
        private CardController _cardController;

        private Action _onHandChange;

        public void Initialize(CardController cardController, int initialHand) {
            _cardController = cardController;
            _cardStatsInHand = new List<CardStats>();
            
            AddCardsToHand(initialHand);
        }

        public int GetCountCardsInHand() {
            return _cardStatsInHand.Count;
        }

        public CardStats GetCardStats(int index) {
            return _cardStatsInHand[index];
        }

        public void SubscribeOnHandChange(Action callback) {
            _onHandChange += callback;
        }

        public void UnsubscribeFromHandChange(Action callback) {
            _onHandChange -= callback;
        }
        
        public void AddCardsToHand(int countToAdd) {
            _cardController.AddCardsToHand(countToAdd, _cardStatsInHand);
            
            _onHandChange?.Invoke();
        }

        public CardStats GetAndRemove(int index) {
            var stat = _cardStatsInHand[index];

            _cardStatsInHand.RemoveAt(index);

            _onHandChange?.Invoke();

            return stat;
        }
    }
}