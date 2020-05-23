using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject PooledObject;
    public int PooledAmount;
    List<GameObject> PooledObjects;

    void Start()
    {
        PooledObjects = new List<GameObject>();
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject Obj = (GameObject)Instantiate(PooledObject);
            Obj.SetActive(false);
            PooledObjects.Add(Obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        GameObject Obj = (GameObject)Instantiate(PooledObject);
        Obj.SetActive(false);
        PooledObjects.Add(Obj);
        return Obj;

    }
}
