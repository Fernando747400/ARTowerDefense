using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PositionsController : MonoBehaviour
{

    public void RePostionGO(ARTrackedImage imageTracked)
    {
       transform.position = imageTracked.transform.position;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
