using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Spawner_UI_Controller : MonoBehaviour
{
    int numInstancesCenter = 0;
    
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject centerPrefab;
    [SerializeField] private GameObject laserPrefab;

    
    [SerializeField] private Text textNumInstances;

    public UnityEvent<bool> ActivatePlaneGenerator;
    

    public void InstanceTower()
    {
        Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
    }
    
    public void InstanceCenter()
    {
        if (numInstancesCenter < 1)
        {
            GameObject center =  Instantiate(centerPrefab, Vector3.zero, Quaternion.identity);
            center.gameObject.name = "Center";
            numInstancesCenter++;
            textNumInstances.text = numInstancesCenter.ToString();
        }
        else
        {
            textNumInstances.color = Color.red;
        }
        

    }
    public void InstanceLaser()
    {
        Instantiate(laserPrefab, Vector3.zero, Quaternion.identity);
        
    }

    public void GeneratePlane(bool active)
    {
        ActivatePlaneGenerator?.Invoke(active);
    }
}
