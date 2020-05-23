using UnityEngine;

public class PlatformGenorator : MonoBehaviour
{
    public GameObject ThePlatform;
    public Transform GenerationPoint;
    public float DistanceBetween;
    private float PlatformWidth;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;
    private int PlatformSelecter;
    //public GameObject[] ThePlatforms;
    private float[] PlatformWidths;
    public ObjectPooler[] TheObjectPools;
    private float MinHeight;
    public Transform MaxHeigthPoint;
    private float MaxHeight;
    public float MaxHeightChange;
    private float HeightChange;
    public CoinGen TheCoinGen;
    public float RandomCoinness;


    void Start()
    {
        //PlatformWidth = ThePlatform.GetComponent<BoxCollider2D>().size.x;
        PlatformWidths = new float[TheObjectPools.Length];
        for(int i = 0; i < TheObjectPools.Length; i++)
        {
            PlatformWidths[i] = TheObjectPools[i].PooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        MinHeight = transform.position.y;
        MaxHeight = MaxHeigthPoint.position.y;
        TheCoinGen = FindObjectOfType<CoinGen>();

    }


    
    void Update()
    {
        if(transform.position.x < GenerationPoint.position.x)
        {
            DistanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
            PlatformSelecter = Random.Range(0, TheObjectPools.Length);
            HeightChange = transform.position.y + Random.Range(MaxHeightChange, -MaxHeightChange);
            if(HeightChange > MaxHeight)
            {
                HeightChange = MaxHeight;
            } else if(HeightChange < MinHeight - 1)
            {
                HeightChange = MinHeight - 1;
            }
            transform.position = new Vector3(transform.position.x + (PlatformWidths[PlatformSelecter] / 2) + DistanceBetween, HeightChange, transform.position.z);
            //Instantiate(/*ThePlatform*/ ThePlatforms[PlatformSelecter], transform.position, transform.rotation);
            GameObject NewPlatform = TheObjectPools[PlatformSelecter].GetPooledObject();
            NewPlatform.transform.position = transform.position;
            NewPlatform.transform.rotation = transform.rotation;
            NewPlatform.SetActive(true);
            if(Random.Range(0f, 100f) < RandomCoinness)
            {
                TheCoinGen.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            transform.position = new Vector3(transform.position.x + (PlatformWidths[PlatformSelecter] / 2), transform.position.y, transform.position.z);

        }
    }
   
}
