using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

namespace Services {
    public class GameController : MonoBehaviour
    {
        private int _countWave;
    
        private int _level;
        public TextMeshProUGUI levelNumber;
    
        public Hero hero;
        public GameObject heroPanel;

        public Enemy enemy;
        public GameObject enemyPanel;

        public Character CurrentMoveCharacter;

        public CardsHandView CardsHandView;
        
        public DamageService DamageService;
        public CameraBlendService CameraBlendService;
        public CardController cardController;

        public void Awake()
        {
            cardController.Initialize();
            
            hero = Instantiate(heroPanel, transform, false).GetComponent<Hero>();
            hero.cardController = cardController;
            hero.gameController = this;

            var sequence = DOTween.Sequence();
            
            CameraBlendService.SwitchToHeroCamera();
            sequence
                .AppendInterval(1)
                .AppendCallback(() => {
                    CameraBlendService.SwitchToMainCamera();
                });
            
            CardsHandView.Initialize(hero.CardsHand, cardController);
            
            hero.Initialize(6);
            
            NextLevel();
            CurrentMoveCharacter = hero;
        }

        private void NextLevel()
        {
            levelNumber.text = ++_level + "st Floor";
        
            _countWave = 1 + _level / 5;
        
            NextWave();
        }
    
        public void NextWave()
        {
            if (_countWave > 0)
            {
                enemy = Instantiate(enemyPanel, transform, false).GetComponent<Enemy>();
                enemy.cardController = cardController;
                enemy.gameController = this;
                
                enemy.Initialize(6);
                
                _countWave--;
            }
            else {
                NextLevel();
            }
        }

        public void EndGame()
        {
            SceneManager.LoadScene(2);
        }
    }
}
