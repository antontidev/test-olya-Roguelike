using System.Collections.Generic;
using DG.Tweening;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Map
{
    public abstract class Station : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _previousStation;

        [SerializeField] private MapController _mapController;

        [SerializeField] private float PathLength;
        public int LevelNumber;
        public int ID;

        public void Start()
        {
            if (LevelNumber <= GameController.Instance.LevelNumber)
                DeactiveThisStation();
        }
        
        public void OnClick()
        {
            var flag = false;
            foreach (var station in _previousStation)
                if (station.GetComponentInChildren<Station>().ID == _mapController.Hero.StationID) flag = true;
            if (!flag) return;
            
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(MoveHero)
                .AppendInterval(3)
                .AppendCallback(() =>
                {
                    SaveMap();
                    DeactivePreviosStation();
                })
                .AppendCallback(Action);
        }

        private void MoveHero()
        {
            _mapController.Hero.Move(transform.position, PathLength);
        }

        private void SaveMap()
        {
            GameController.Instance.StationID = ID;
            GameController.Instance.LevelNumber = LevelNumber;
            GameController.Instance.transform.position = transform.position;
        }

        private void DeactivePreviosStation()
        {
            foreach (var station in _previousStation)
            {
                if (station.GetComponentInChildren<Station>().ID == _mapController.Hero.StationID) 
                    station.GetComponent<Button>().enabled = false;
            }
        }
        
        protected abstract void Action();

        private void DeactiveThisStation()
        {
            GetComponent<Button>().enabled = false;
        }
    }
}