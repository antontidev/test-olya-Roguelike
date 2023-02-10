using UnityEngine;

public class CameraMap : MonoBehaviour
{
    public Map.HeroMap Hero;

    private void Update()
    {
        transform.position = Hero.transform.position;
    }
}