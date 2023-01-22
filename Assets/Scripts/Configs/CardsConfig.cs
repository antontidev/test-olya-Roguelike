using System.Collections.Generic;
using UnityEngine;

namespace Configs {
    [CreateAssetMenu(menuName = "Configs/Cards/Cards config", fileName = "CardsConfig")]
    public class CardsConfig : ScriptableObject {
        public List<CardStats> Config;

        public int GetCardsCount() {
            return Config.Count;
        }
    }
}