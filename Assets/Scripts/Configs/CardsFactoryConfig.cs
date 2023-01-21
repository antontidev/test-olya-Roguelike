using UnityEngine;

namespace Configs {
    [CreateAssetMenu(menuName = "Configs/Factory/Cards factory", fileName = "CardsFactoryConfig")]
    public class CardsFactoryConfig : ScriptableObject {
        public GameObject CardPrefab;

        public int InitialCount;
    }
}