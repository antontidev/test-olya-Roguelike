using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        public List<Enemy> Enemy;
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
            var random = new System.Random();
            var countEnemy = random.Next(1,4);
            EnemiesTurn = 0;
            if (_countWave > 0)
            {
                for (var i = 0; i < countEnemy; i++)
                {
                    var enemy = Instantiate(_enemyPanel, transform, false);
                    enemy.gameObject.transform.position = new Vector3(enemy.gameObject.transform.position.x + i*3f,
                        enemy.gameObject.transform.position.y, 0);
                    
                    Enemy.Add(enemy.GetComponent<Enemy>());
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
                CurrentMoveCharacter = ((EnemiesTurn >= Enemy.Count - 1) ? Enemy[EnemiesTurn = 0] : Enemy[++EnemiesTurn]);
            else CurrentMoveCharacter = Hero;
        }
    }
}
