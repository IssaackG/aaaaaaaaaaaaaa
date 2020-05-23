using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Player.position.y, transform.position.z);
        
    }
}
