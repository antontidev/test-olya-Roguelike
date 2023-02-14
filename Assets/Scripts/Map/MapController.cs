using System;
using Services;
using UnityEngine;

namespace Map
{
    public class MapController : MonoBehaviour
    {
        [Header("Герой")]
        public HeroMap Hero;
        [SerializeField] private GameObject _heroMapPrefab;

        [SerializeField]
        private GameObject _shop;

        private void Start()
        {
            GameController.Instance.MapController = this;
            Hero.transform.position = GameController.Instance.transform.position;
        }

        public void ChangeOnNextLevel()
        {
            ++GameController.Instance.LevelNumber;
        }


        public void OpenShop()
        {
            _shop.SetActive(true);
        }
    }
}