using Core.Pools;
using UnityEngine;

namespace Configs.Enemies {
    [CreateAssetMenu(menuName = "Configs/Factory/Enemies factory", fileName = "EnemiesFactoryConfig")]
    public class EnemiesFactoryConfig : ScriptableObject {
        public GameObject EnemyPrefab;

        public int InitialCount;
        public ExpandType ExpandType;
        public ExpandType ExpandPercent;
    }
}