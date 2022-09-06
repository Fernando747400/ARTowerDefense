using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PositionsController : MonoBehaviour
{

    public void RePostionGO(ARTrackedImage imageTracked, Text text)
    { 
        text.text = "Se repos obj = " + gameObject.name + " to =" + imageTracked.transform.position; 
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
