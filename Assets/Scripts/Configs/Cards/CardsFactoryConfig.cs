using Core.Pools;
using UnityEngine;

namespace Configs.Cards {
    [CreateAssetMenu(menuName = "Configs/Factory/Cards factory", fileName = "CardsFactoryConfig")]
    public class CardsFactoryConfig : ScriptableObject {
        public GameObject CardPrefab;

        public int InitialCount;
        public ExpandType ExpandType;
        public ExpandType ExpandPercent;
    }
}