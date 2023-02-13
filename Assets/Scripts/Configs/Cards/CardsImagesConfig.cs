using Core;
using UnityEngine;

namespace Configs.Cards {
    [CreateAssetMenu(menuName = "Configs/Cards/Cards images", fileName = "CardsImagesConfig")]
    public class CardsImagesConfig : ScriptableObject {
        public StringToSpriteDictionary Config;
    }
}