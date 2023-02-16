using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Views;

namespace Services {
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelNumber;
        
        [HideInInspector] 
        public Character CurrentMoveCharacter;
        private int _countWave;
    
        [Header("Герой")]
        [HideInInspector] 
        public Hero Hero;
        [SerializeField] private GameObject _heroPanel;
        
        [Header("Враг")]
        [HideInInspector] 
        public Enemy[] Enemy;
        [SerializeField] private GameObject _enemyPanel;
        private int EnemiesTurn;
        
        [Header("Контроллеры и сервисы")]
        public MoveView MoveView;
        public CardsHandView CardsHandView;
        public CardController CardController;
        public MoveController MoveController;
        public CameraBlendService CameraBlendService;

        public void Awake()
        {
            CardController.Initialize();
            
            Hero = Instantiate(_heroPanel, transform, false).GetComponent<Hero>();
            
            CardsHandView.Initialize(Hero.CardsHand, CardController);
            
            Hero.Initialize(this,6);
            
            CameraBlendService
                .StartSequence()
                .AppendHeroSwitch()
                .AppendMainSwitch();
            
            NextLevel();
            CurrentMoveCharacter = Hero;
        }

        private void NextLevel()
        {
            // levelNumber.text = GameController.Instance.LevelNumber + "st Floor";
        
            _countWave = 1 + GameController.Instance.LevelNumber / 5;
        
            NextWave();
        }
    
        public void NextWave()
        {
            Enemy = false ? new Enemy[2] : new Enemy[1];
            EnemiesTurn = 0;
            if (_countWave > 0)
            {
                for (var i = 0; i < Enemy.Length; i++)
                {
                    Enemy[i] = Instantiate(_enemyPanel, transform, false).GetComponent<Enemy>();
                    Enemy[i].Initialize(this, 6);
                }
                
                _countWave--;
            }
            else
                GameController.Instance.EndLevel(EndLevel.Win);
        }

        public void GameLoss()
        {
            GameController.Instance.EndLevel(EndLevel.Loss);
        }

        public void SwitchCurrentMoveCharacter()
        {
            if (CurrentMoveCharacter is Hero)
                CurrentMoveCharacter = (EnemiesTurn == Enemy.Length - 1) ? Enemy[EnemiesTurn = 0] : Enemy[++EnemiesTurn];
            else CurrentMoveCharacter = Hero;
        }
    }
}
