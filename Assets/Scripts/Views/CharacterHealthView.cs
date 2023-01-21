using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views {
    public class CharacterHealthView : MonoBehaviour {
        public Slider Slider;
        public TextMeshProUGUI CountOfHealth;
        public Image SliderImage;

        public void SetMaxHealth(int maxHealth) {
            Slider.maxValue = maxHealth;

            SetHealth(maxHealth);
        }

        public void SetHealth(int health) {
            Slider.value = health;

            CountOfHealth.text = Slider.value + "/" + Slider.maxValue;
        }

        public void SetSliderColor(Color color) {
            SliderImage.color = color;
        }
    }
}