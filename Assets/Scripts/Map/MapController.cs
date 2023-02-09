using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Map
{
    public class MapController : MonoBehaviour
    {
        [Header("Герой")]
        public HeroMap Hero;
        [SerializeField] private GameObject _heroMapPrefab;
        
        private void Awake()
        {
            // Hero = Instantiate(_heroMapPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<HeroMap>();
        }
    }
}