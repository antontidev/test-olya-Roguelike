using DG.Tweening;
using UnityEngine;

namespace Map
{
    public class HeroMap : MonoBehaviour
    {
        private Hero _hero;
        public Station Station;
        
        public void Move(Vector3 newPosition)
        {
            transform.DOMove(newPosition, 3f);
        }
    }
}