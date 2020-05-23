using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject PlatformDelPoint;

    void Start()
    {
        PlatformDelPoint = GameObject.Find("PlatformDelPoint");
    }


    void Update()
    {
        if(transform.position.x < PlatformDelPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
