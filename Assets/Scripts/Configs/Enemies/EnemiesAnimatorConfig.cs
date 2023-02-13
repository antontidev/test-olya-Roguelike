using Core;
using UnityEngine;

namespace Configs.Enemies {
    [CreateAssetMenu(menuName = "Configs/Enemies/Enemies animator", fileName = "EnemiesAnimatorConfig")]
    public class EnemiesAnimatorConfig : ScriptableObject {
        public StringToSpriteDictionary Config;
    }
}