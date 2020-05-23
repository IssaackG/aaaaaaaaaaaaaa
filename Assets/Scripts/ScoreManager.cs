using UnityEngine.UI;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighscoreText;
    public float ScoreCount;
    public float HighscoreCount;
    public PlayerMovement ThePlayer;
    public bool ScoreIncreasing;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighscoreCount = PlayerPrefs.GetFloat("Highscore");
        }
        
    }

    
    void Update()
    {
        
        if (ScoreIncreasing)
        {
            ScoreCount += ThePlayer.MovementSpeed * Time.deltaTime;
        }
        if(ScoreCount > HighscoreCount)
        {
            HighscoreCount = ScoreCount;
            PlayerPrefs.SetFloat("Highscore", HighscoreCount);
        }
        ScoreText.text = "Score: " + Mathf.Round(ScoreCount);
        HighscoreText.text = "Highscore: " + Mathf.Round(HighscoreCount);
    }
    public void AddScore(int PointsToAdd)
    {
        ScoreCount += PointsToAdd;
    }
}
