using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpawnerUI_CodeXR : MonoBehaviour
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
