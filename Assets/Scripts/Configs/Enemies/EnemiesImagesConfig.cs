using Core;
using UnityEngine;

namespace Configs.Enemies {
    [CreateAssetMenu(menuName = "Configs/Enemies/Enemies images", fileName = "EnemiesImagesConfig")]
    public class EnemiesImagesConfig : ScriptableObject {
        public StringToSpriteDictionary Config;
    }
}