using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Enemies {
    [CreateAssetMenu(menuName = "Configs/Enemies/Enemies config", fileName = "EnemiesConfig")]
    public class EnemiesConfig : ScriptableObject
    {
        public List<EnemyStats> Config;
        
        private List<EnemyStats> _enemiesList;
        private System.Random _random;
            
        public void Initialize()
        {
            _random = new System.Random();
            _enemiesList = new List<EnemyStats>();
    
            CorrectChance();
            
            for (var j = 0; j < Config.Count; j++)
            for (var i = 0; i < Config[j].Chance * 10; i++)
                _enemiesList.Add(Config[j]);
                
            //лишняя проверочка
            if (_enemiesList.Count != 1000)
                throw new ArgumentException("Врагов не 1000");
        }
    
        public int GetEnemiesCount() {
            return Config.Count;
        }
    
        public CharacterStats[] GetRandomEnemy()
        {
            CharacterStats[] randomEnemyStats;
            
            //TODO условия генерации одного или двух врагов в зависимости от уровня игры
            randomEnemyStats = true ? new CharacterStats[2] : new CharacterStats[1];
            for (var i = 0; i < randomEnemyStats.Length; i++)
                randomEnemyStats[i] = _enemiesList[_random.Next(_enemiesList.Count)].CharacterStats;
            return randomEnemyStats;
        }

        private void CorrectChance()
        {
            var chance = 0f;
            for (int i = 0; i < Config.Count; i++)
                chance += Config[i].Chance;
            if (chance != 100f)
                throw new ArgumentException("Некорректная вероятность выпадения врагов");
        }
    }
}