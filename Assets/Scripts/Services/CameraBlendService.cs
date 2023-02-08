using Cinemachine;
using DefaultNamespace;
using UnityEngine;

namespace Services {
    public class CameraBlendService : MonoBehaviour {
        
        [SerializeField]
        private CinemachineVirtualCamera mainCamera, heroCamera, enemyCamera;

        [SerializeField]
        private CameraBlendSettings _settings;
        
        public CameraSequence StartSequence() {
            return new CameraSequence(this, _settings);
        }
            
        public int currentPriority;
        public int otherPriority;

        public CinemachineBlenderSettings blenderSettings;

        public void SwitchToMainCamera() {
            mainCamera.Priority = currentPriority;
            heroCamera.Priority = otherPriority;
            enemyCamera.Priority = otherPriority;
        }

        public void SwitchToEnemyCamera() {
            enemyCamera.Priority = currentPriority;
            mainCamera.Priority = otherPriority;
            heroCamera.Priority = otherPriority;
        }

        public void SwitchToHeroCamera() {
            heroCamera.Priority = currentPriority;
            mainCamera.Priority = otherPriority;
            enemyCamera.Priority = otherPriority;
        }
    }
}