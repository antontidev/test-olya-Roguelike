﻿using System;
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

        [SerializeField]
        private ShopMenu _shop;

        
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
            _shop.gameObject.SetActive(true);
            _shop.CardsRoot.SubscribeOnBonusPicked(BuffHeroWithBonuses);
        }

        public void BuffHeroWithBonuses()
        {
            BonusStats pickedBonus = _shop.CardsRoot.pickedBonus;
            Hero.HeroStats.BuffStats(pickedBonus);
        }
    }
}