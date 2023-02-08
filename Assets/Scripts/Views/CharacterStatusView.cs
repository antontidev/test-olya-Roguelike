using Configs;
using UnityEngine;

namespace Views {
    public class CharacterStatusView : MonoBehaviour {
        [SerializeField]
        private CharacterDefenceView _characterDefenceView;

        [SerializeField]
        private CharacterHealthView _characterHealthView;

        [SerializeField]
        private StatusViewConfig _statusViewConfig;
        
        public void SetHealth(int health) {
            _characterHealthView.SetHealth(health);
        }

        public void SetMaxHealth(int maxHealth) {
            _characterHealthView.SetMaxHealth(maxHealth);
        }

        public void SetDefense(int defence) {
            if (defence > 0) {
                _characterHealthView.SetSliderColor(_statusViewConfig.ActiveDefenceHealthBarColor);
            }
            else {
                _characterHealthView.SetSliderColor(_statusViewConfig.InactiveDefenceHealthBarColor);
            }
            
            _characterDefenceView.SetDefence(defence);
        }
    }
}