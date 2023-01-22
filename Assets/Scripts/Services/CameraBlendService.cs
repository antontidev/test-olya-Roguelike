using Cinemachine;
using UnityEngine;

namespace Services {
    public class CameraBlendService : MonoBehaviour {
        [SerializeField]
        private CinemachineVirtualCamera _mainCamera, _heroCamera, _enemyCamera;

        public int _currentPriority;
        public int _otherPriority;

        public CinemachineBlenderSettings BlenderSettings;

        public void SwitchToMainCamera() {
            _mainCamera.Priority = _currentPriority;
            _heroCamera.Priority = _otherPriority;
            _enemyCamera.Priority = _otherPriority;
        }

        public void SwitchToEnemyCamera() {
            _enemyCamera.Priority = _currentPriority;
            _mainCamera.Priority = _otherPriority;
            _heroCamera.Priority = _otherPriority;
        }

        public void SwitchToHeroCamera() {
            _heroCamera.Priority = _currentPriority;
            _mainCamera.Priority = _otherPriority;
            _enemyCamera.Priority = _otherPriority;
        }
    }
}