using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSize : MonoBehaviour
{
    public GameObject scaler = null;
    
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Increse()
    {
        scaler.GetComponent<Transform>().localScale += new Vector3(1, 1, 0);
        scaler.GetComponent<Transform>().localPosition += new Vector3(0, 1, 0);
    }
}
