using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform Player;
    public float Offset;
 
    void Update()
    {
        transform.position = new Vector3(Player.position.x + Offset, transform.position.y, transform.position.z);
    }
}
