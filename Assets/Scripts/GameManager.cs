using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform PlatformGen;
    private Vector3 PlatformStartPoint;
    public PlayerMovement ThePlayer;
    private Vector3 PlayerStartPoint;
    private PlatformDestroyer[] PlatformList;
    public Vector3 PlayerOffset;
    private ScoreManager TheScoreManager;

    void Start()
    {
        PlatformStartPoint = PlatformGen.position;
        PlayerStartPoint = ThePlayer.transform.position;
        TheScoreManager = FindObjectOfType<ScoreManager>();
    }


    void Update()
    {
        
    }
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }
    public IEnumerator RestartGameCo()
    {
        TheScoreManager.ScoreIncreasing = false;
        ThePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        PlatformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < PlatformList.Length; i++)
        {
            PlatformList[i].gameObject.SetActive(false);
        }
        ThePlayer.transform.position = PlatformStartPoint + PlayerOffset;
        PlatformGen.position = PlatformStartPoint;
        ThePlayer.gameObject.SetActive(true);
        TheScoreManager.ScoreCount = 0;
        TheScoreManager.ScoreIncreasing = true;
    }
}
