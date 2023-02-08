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
    
        [Header("Герой")]
        public Hero hero;
        public GameObject heroPanel;
        
        [Header("Враг")]
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
            // hero.Initialize(this, cardController, 6);

            CameraBlendService
                .StartSequence()
                .AppendHeroSwitch()
                .AppendMainSwitch();

            CardsHandView.Initialize(hero.CardsHand, cardController);
            
            hero.Initialize(this, cardController,6);
            
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
                enemy.Initialize(this, cardController,6);
                
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

        public void SwitchCurrentMoveCharacter()
        {
            if (CurrentMoveCharacter is Hero) CurrentMoveCharacter = enemy;
            else CurrentMoveCharacter = hero;
        }
    }
}
