using Services;
using UnityEngine;

namespace Map
{
    public class MapController : MonoBehaviour
    {
        [Header("Герой")]
        public HeroMap Hero;
        [SerializeField] private GameObject _heroMapPrefab;
        public Transform Camera;

        public void Start()
        {
            Hero.transform.position = GameController.Instance.transform.position;
            Camera.transform.position = new Vector3(0, Hero.transform.position.y + 4, -10);
        }
    }
}