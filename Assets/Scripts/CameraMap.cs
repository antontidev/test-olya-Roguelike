using UnityEngine;
public class CameraMap : MonoBehaviour
{
    public Transform HeroToFollow;
    private Vector3 _deltaPos;

    public void Start()
    {
        _deltaPos = transform.position - HeroToFollow.position;
    }

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, HeroToFollow.position.y + _deltaPos.y, -10);
    }
}