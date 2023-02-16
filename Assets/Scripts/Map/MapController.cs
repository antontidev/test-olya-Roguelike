using System;
using Cards;
using Services;
using UnityEngine;

namespace Map
{
    public class MapController : MonoBehaviour
    {
        [Header("Герой")]
        public HeroMap Hero;
        [SerializeField] private GameObject _heroMapPrefab;
        public Transform Camera;

        [SerializeField]
        private ShopMenu _shop;

        
        private void Start()
        {
            GameController.Instance.MapController = this;
            Hero.transform.position = GameController.Instance.transform.position;
            Camera.transform.position = new Vector3(0, Hero.transform.position.y + 4, -10);
        }

        public void ChangeOnNextLevel()
        {
            ++GameController.Instance.LevelNumber;
        }


        public void OpenShop()
        {
            _shop.gameObject.SetActive(true);
            _shop.CardsRoot.SubscribeOnBonusPicked(BuffHeroWithBonuses);
        }

        public void BuffHeroWithBonuses()
        {
            BonusStats pickedBonus = _shop.CardsRoot.pickedBonus;
            _shop.CardsRoot.UnSubscribeOnBonusPicked(BuffHeroWithBonuses);
            GameController.Instance.CharacterStats.BuffStats(pickedBonus);
            _shop.gameObject.SetActive(false);
        }
    }
}