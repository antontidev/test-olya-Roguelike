using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Bonus
{
    [CreateAssetMenu(menuName = "Configs/Bonus/Bonus config", fileName = "BonusConfig")]
    public class BonusConfig : ScriptableObject
    {
        public List<BonusStats> Config;

        private List<BonusStats> _bonusesList;
        private System.Random _random;

        public void Initialize()
        {
            _random = new System.Random();
            _bonusesList = new();

            if (!IsCorrectChance()) throw new ArgumentException("Некорректная вероятность выпадения карт");

            for (int i = 0; i < Config.Count; i++)
            {
                for (int j = 0; j < Config[i].Chance * 10; j++)
                {
                        _bonusesList.Add(Config[i]);
                }
            }
        
        }

        public BonusStats GetRandomBonusItem()
        {
            return _bonusesList[_random.Next(_bonusesList.Count)];  
        }

        private bool IsCorrectChance()
        {
            var chance = 0f;
            foreach (var item in Config)
            {
                chance += item.Chance;
            }
            var returnValue = Mathf.Abs(chance - 100f) < 0.001;
            return returnValue;
            
        }
    }
}

