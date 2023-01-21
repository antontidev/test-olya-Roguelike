using UnityEngine;

namespace Configs {
    [CreateAssetMenu(menuName = "Configs/Views/Status view", fileName = "StatusViewConfig")]
    public class StatusViewConfig : ScriptableObject {
        public Color ActiveDefenceHealthBarColor;
        public Color InactiveDefenceHealthBarColor;
    }
}