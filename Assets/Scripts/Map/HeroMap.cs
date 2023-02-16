using System;
using DG.Tweening;
using Services;
using UnityEngine;

namespace Map
{
    public class HeroMap : MonoBehaviour
    {
        private CharacterStats _heroStats;

        public SpriteRenderer SpriteRenderer;
        
        public int StationID;

        private void Awake()
        {
            StationID = GameController.Instance.StationID;
        }

        public void Move(Vector3 newPosition, float pathLength)
        {
            var pos = newPosition.x-transform.position.x;
            SpriteRenderer.flipX = pos > 0;
            transform.DOMove(newPosition, pathLength);
        }
    }
}