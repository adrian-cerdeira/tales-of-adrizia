using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject poolObject;

    public int objectAmount;

    List<GameObject> lObjects;

    // Start is called before the first frame update
    void Start()
    {
        lObjects = new List<GameObject>();
        
        for(int i = 0; i < objectAmount; i++)
        {
            AddPoolObject();
        }
    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject obj in lObjects)
        {
            if(!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return AddPoolObject();
    }

    private GameObject AddPoolObject()
    {
        GameObject obj = Instantiate(poolObject);
        obj.SetActive(false);

        lObjects.Add(obj);

        return obj;
    }
}
