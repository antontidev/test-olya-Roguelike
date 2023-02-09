using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Map
{
    public abstract class Station : MonoBehaviour
    {
        [SerializeField] private HeroMap _hero;
        
        [SerializeField] private List<GameObject> _previousStation;

        [SerializeField] private MapController _mapController;

        public void OnClick()
        {
            // _hero = _mapController.Hero;
            var flag = false;
            foreach (var station in _previousStation)
                if (station.GetComponent<Station>() == _hero.Station) flag = true;
            if (!flag) return;

            _hero.Station = this;
            
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(MoveHero)
                .AppendCallback(DeactivePreviosStation)
                .AppendInterval(3)
                .AppendCallback(Action)
                .AppendCallback(DeactiveThisStation);
        }

        private void MoveHero()
        {
            _hero.Move(transform.position);
        }

        private void DeactivePreviosStation()
        {
            foreach (var station in _previousStation)
            {
                station.GetComponent<Button>().enabled = false;
            }
        }
        
        protected abstract void Action();
        
        public void DeactiveThisStation()
        {
            GetComponent<Button>().enabled = false;
        }
    }
}