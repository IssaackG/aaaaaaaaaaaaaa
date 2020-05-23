using UnityEngine;

public class PickupPoints : MonoBehaviour
{
    public int ScoreToGive;
    private ScoreManager TheScoreManager;

    void Start()
    {
        TheScoreManager = FindObjectOfType<ScoreManager>();
    }

  
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            TheScoreManager.AddScore(ScoreToGive);
            gameObject.SetActive(false);
        }
    }
}
