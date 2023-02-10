using System;
using DG.Tweening;
using Services;
using UnityEngine;

namespace Map
{
    public class HeroMap : MonoBehaviour
    {
        private CharacterStats _heroStats;
        
        public int StationID;

        private void Awake()
        {
            _heroStats = global::HeroMap.Heroes[0];
            StationID = GameController.Instance.StationID;
        }

        public void Move(Vector3 newPosition, float pathLength)
        {
            transform.DOMove(newPosition, pathLength);
        }
    }
}