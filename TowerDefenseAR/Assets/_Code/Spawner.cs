using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject centerPrefab;
    [SerializeField] private GameObject laserPrefab;
    

    public void InstanceTower()
    {
        Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
    }
    
    public void InstanceCenter()
    {
        Instantiate(centerPrefab, Vector3.zero, Quaternion.identity);
        
    }
    public void InstanceLaser()
    {
        Instantiate(laserPrefab, Vector3.zero, Quaternion.identity);
        
    }
}
