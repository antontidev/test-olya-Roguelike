using Configs.Bonus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class ItemManager : MonoBehaviour
    {
        public int countCards;

        public BonusConfig BonusConfig;

        public ShopItemView BonusPrefab;

        private void Awake()
        {
            BonusConfig.Initialize();

            for (int i = 0; i < countCards; i++)
            {
                ShopItemView spawnedItem = Instantiate(BonusPrefab);
                spawnedItem.transform.SetParent(transform, false);
                spawnedItem.Initialize(BonusConfig.GetRandomBonusItem());
            }
            //foreach (GameObject item in ShopItems)
            //{
            //    GameObject spawnedItem = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
            //    spawnedItem.transform.SetParent(transform, false);
            //}
        }
    }
}
