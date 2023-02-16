using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [HideInInspector] 
        public int LevelNumber;
        [HideInInspector]
        public int StationID;
        [HideInInspector]
        public CharacterStats CharacterStats;

        private void OnEnable()
        {
            DontDestroyOnLoad(gameObject);

            Initialize();

            SceneManager.LoadScene(0);
        }
        
        private void Initialize()
        {
            Instance = this;
            
            LevelNumber = 0;
            StationID = 0;
            CharacterStats = HeroMap.Heroes[0];
            
            transform.position = new Vector3(0, -4, 0);
        }

        public void StartLevel()
        {
            SceneManager.LoadScene(1);
        }

        public void EndLevel(EndLevel endLevel)
        {
            switch (endLevel)
            {
                case global::EndLevel.Win:
                    SceneManager.LoadScene(0);
                    break;
                case global::EndLevel.Loss:
                    SceneManager.LoadScene(2);
                    break;
            }
        }
       
        public void ChangeOnNextLevel()
        {
            ++LevelNumber;
        }

        // public void Save(Transform currentPlayerPosition)
        // {
        //     transform.position = currentPlayerPosition.position;
        //
        //     var position = transform.position;
        //
        //     PlayerPrefs.SetFloat("PosX", position.x); 
        //     PlayerPrefs.SetFloat("PosY", position.y);
        //     PlayerPrefs.SetFloat("PosZ", position.z); 
        //
        //     PlayerPrefs.SetInt("LevelNumber", LevelNumber);
        //     PlayerPrefs.SetInt("StationID", StationID);
        // }
	
        // public void Load(GameObject hero)
        // {
        //     transform.position = new Vector3(
        //         PlayerPrefs.GetFloat("PosX"), 
        //         PlayerPrefs.GetFloat("PosY"), 
        //         PlayerPrefs.GetFloat("PosZ"));
        //
        //     LevelNumber = PlayerPrefs.GetInt("LevelNumber");
        //     StationID = PlayerPrefs.GetInt("StationID");
        // }
    }
}