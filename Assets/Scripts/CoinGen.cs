using UnityEngine;

public class CoinGen : MonoBehaviour
{
    public ObjectPooler CoinPool;
    public float DistanceBetweenCoins;
    public int dfhhdffgfj;

    public void SpawnCoins(Vector3 StartPosition)
    {
        GameObject Coin1 = CoinPool.GetPooledObject(); 
        Coin1.transform.position = StartPosition;
        Coin1.SetActive(true);
        
        GameObject Coin2 = CoinPool.GetPooledObject();
        Coin2.transform.position = new Vector3(StartPosition.x - DistanceBetweenCoins, StartPosition.y, StartPosition.z);
        Coin2.SetActive(true);
        
        GameObject Coin3 = CoinPool.GetPooledObject();
        Coin3.transform.position = new Vector3(StartPosition.x + DistanceBetweenCoins, StartPosition.y, StartPosition.z);
        Coin3.SetActive(true);
    }
    
   
}      
    

