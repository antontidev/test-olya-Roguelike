using DG.Tweening;
using Map;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        // [HideInInspector]
        public int LevelNumber;
        // [HideInInspector]
        public int StationID;

        public CharacterStats CharacterStats;

        [HideInInspector]
        public MapController MapController;

        private void OnEnable()
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);

            var seq = DOTween.Sequence();
            seq.AppendCallback(InitializeManager)
                .AppendCallback(() =>
                {
                    SceneManager.LoadScene(0);
                });

        }
        
        private void InitializeManager()
        {
            LevelNumber = 0;
            StationID = 0;
            transform.position = new Vector3(0, -4, 0);

            CharacterStats = HeroMap.Heroes[0];

            Save(transform);
        }

        public void StartLevel(Transform currentPlayerPosition)
        {
            Save(currentPlayerPosition);
            SceneManager.LoadScene(1);
        }

        public void LevelWin()
        {
            var seq = DOTween.Sequence();
            seq.AppendCallback(() =>
                {
                    SceneManager.LoadScene(0);
                })
                .AppendInterval(0)
                .AppendCallback(() =>
                {
                    Load(MapController.Hero.gameObject);
                });
        }

        public void LevelLoss()
        {
            SceneManager.LoadScene(2);
        }

        public void Save(Transform currentPlayerPosition)
        {
            transform.position = currentPlayerPosition.position;

            var position = transform.position;

            PlayerPrefs.SetFloat("PosX", position.x); 
            PlayerPrefs.SetFloat("PosY", position.y);
            PlayerPrefs.SetFloat("PosZ", position.z); 

            PlayerPrefs.SetInt("LevelNumber", LevelNumber);
            PlayerPrefs.SetInt("StationID", StationID);
        }
	
        public void Load(GameObject hero)
        {
            transform.position = new Vector3(
                PlayerPrefs.GetFloat("PosX"), 
                PlayerPrefs.GetFloat("PosY"), 
                PlayerPrefs.GetFloat("PosZ"));

            LevelNumber = PlayerPrefs.GetInt("LevelNumber");
            StationID = PlayerPrefs.GetInt("StationID");
        }
    }
}