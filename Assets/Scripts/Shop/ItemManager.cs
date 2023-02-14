using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class ItemManager : MonoBehaviour
    {
        public List<GameObject> ShopItems= new List<GameObject>();

        private void Awake()
        {
            foreach (GameObject item in ShopItems)
            {
                GameObject spawnedItem = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
                spawnedItem.transform.SetParent(transform, false);
            }
        }
    }
}
