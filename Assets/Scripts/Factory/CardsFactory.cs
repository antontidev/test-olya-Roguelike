using Configs;
using Core;
using Core.Pools.Base;
using UnityEngine;

namespace Factory {
    public class CardsFactory {
        private readonly CardsFactoryConfig _config;
        private readonly Transform _parent;
        
        private readonly GameObjectsPool _cardsPool;

        public CardsFactory(CardsFactoryConfig config, Transform parent) {
            _config = config;
            _parent = parent;

            _cardsPool = new GameObjectsPool(config.CardPrefab, config.ExpandType, config.ExpandPercent, config.InitialCount);
            _cardsPool.SetParentContainer(parent);
        }

        public void Initialize() {
            _cardsPool.InitialFill();
        }

        public Card GetCard() {
            return _cardsPool.Take<Card>(true);
        }

        public void Release(Card obj) {
            _cardsPool.Release(obj, true);
        }
    }
}