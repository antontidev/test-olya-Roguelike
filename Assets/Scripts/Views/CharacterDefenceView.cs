using TMPro;
using UnityEngine;

namespace Views {
    public class CharacterDefenceView : MonoBehaviour {
        public GameObject LogoHealth;
        public GameObject LogoDefence;
        public TextMeshProUGUI TextDefence;

        public void SetDefence(int defence)
        {
            if (defence == 0)
            {
                LogoDefence.SetActive(false);
                LogoHealth.SetActive(true);
            }
            else
            {
                LogoDefence.SetActive(true);
                LogoHealth.SetActive(false);
                TextDefence.text = defence.ToString();
            }
        }
    }
}