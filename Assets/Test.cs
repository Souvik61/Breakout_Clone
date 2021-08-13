using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject gh;

    void Start()
    {
        int count = 0;
        foreach (Transform item in transform)
        {
            Debug.Log(item.gameObject.name);
            count++;
        }
        Debug.Log(count);
 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
