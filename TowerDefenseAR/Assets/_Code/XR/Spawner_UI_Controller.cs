using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Spawner_UI_Controller : MonoBehaviour
{
    // int numInstancesCenter = 0;
    
    [SerializeField] private Text textNumInstances;
    private UnityEvent<bool> ActivatePlaneGenerator;
    public Action<GameObject> OnChangePrefab;
    
    
    public void SelectPrefab(GameObject prefab)
    {
        OnChangePrefab?.Invoke(prefab);
    }
    
    public void GeneratePlane(bool active)
    {
        ActivatePlaneGenerator?.Invoke(active);
    }
    
}
