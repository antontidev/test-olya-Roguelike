using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

namespace Services {
    public class BattleController : MonoBehaviour
    {
        private int _countWave;
    
        public TextMeshProUGUI levelNumber;
    
        [Header("Герой")]
        public Hero hero;
        public GameObject heroPanel;
        
        [Header("Враг")]
        public Enemy enemy;
        public GameObject enemyPanel;

        public Character CurrentMoveCharacter;

        public CardsHandView CardsHandView;
        
        public CameraBlendService CameraBlendService;
        public CardController cardController;

        public void Awake()
        {
            cardController.Initialize();
            
            hero = Instantiate(heroPanel, transform, false).GetComponent<Hero>();

            CardsHandView.Initialize(hero.CardsHand, cardController);
            
            hero.Initialize(this, cardController,6);
            
            CameraBlendService
                .StartSequence()
                .AppendHeroSwitch()
                .AppendMainSwitch();
            
            NextLevel();
            CurrentMoveCharacter = hero;
        }

        private void NextLevel()
        {
            levelNumber.text = GameController.Instance.LevelNumber + "st Floor";
        
            _countWave = 1 + GameController.Instance.LevelNumber / 5;
        
            NextWave();
        }
    
        public void NextWave()
        {
            if (_countWave > 0)
            {
                enemy = Instantiate(enemyPanel, transform, false).GetComponent<Enemy>();
                enemy.Initialize(this, cardController,6);
                
                _countWave--;
            }
            else {
                GameController.Instance.LevelWin();
            }
        }

        public void GameLoss()
        {
            GameController.Instance.LevelLoss();
        }

        public void SwitchCurrentMoveCharacter()
        {
            if (CurrentMoveCharacter is Hero) CurrentMoveCharacter = enemy;
            else CurrentMoveCharacter = hero;
        }
    }
}
