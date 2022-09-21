using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpawnerUI_CodeXR : MonoBehaviour
{
    // int numInstancesCenter = 0;
    
    private UnityEvent<bool> ActivatePlaneGenerator;
    public Action<GameObject> OnChangePrefab;
    public Action<int> OnSelectType;
    
    public void SelectPrefab(GameObject prefab)
    {
        OnChangePrefab?.Invoke(prefab);
    }

    public void SelectType(int type)
    {
        OnSelectType?.Invoke(type);
    }
    
    public void GeneratePlane(bool active)
    {
        ActivatePlaneGenerator?.Invoke(active);
    }
    
}
