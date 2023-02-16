using System;
using DG.Tweening;
using Services;
using UnityEngine;

namespace Map
{
    public class HeroMap : MonoBehaviour
    {        
        public int StationID;

        private void Awake()
        {
            StationID = GameController.Instance.StationID;
        }

        public void Move(Vector3 newPosition, float pathLength)
        {
            transform.DOMove(newPosition, pathLength);
        }
    }
}