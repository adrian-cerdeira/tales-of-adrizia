using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Transform destroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("DestroyPoint").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= destroyPoint.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
