using Characters;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Views;

namespace Services {
    public class GameController : MonoBehaviour
    {
        private int _countWave;
    
        private int _level;
        public TextMeshProUGUI LevelNumber;
    
        public Hero Hero;
        public GameObject HeroPanel;

        public Enemy Enemy;
        public GameObject EnemyPanel;

        public Character CurrentMoveCharacter;

        public DamageService DamageService;
        public CameraBlendService CameraBlendService;
        public CardController CardController;
        
        public void Awake()
        {
            _level = 0;
            
            CardController.Initialize();

            Hero = Instantiate(HeroPanel, transform, false).GetComponent<Hero>();
            Hero.Initialize(CardController,this,6);
            
            CameraBlendService
                .StartSequence()
                .AppendHeroSwitch()
                .AppendMainSwitch();

            NextLevel();
            CurrentMoveCharacter = Hero; //?
        }

        private void NextLevel()
        {
            LevelNumber.text = ++_level + "st Floor";
            _countWave = 1 + _level / 5;
            NextWave();
        }
    
        public void NextWave()
        {
            if (_countWave > 0)
            {
                Enemy = Instantiate(EnemyPanel, transform, false).GetComponent<Enemy>();
                Enemy.Initialize(CardController,this,6);
                
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
