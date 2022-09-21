using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    bool startSpawn = false;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        if(startSpawn)
        {
            ObjectPooler.Instance.SpawnFromPool("tank", transform.position, Quaternion.identity);
            ObjectPooler.Instance.SpawnFromPool("jump", transform.position, Quaternion.identity);
        }
        
    }

    public void SpawnerStart()
    {
        startSpawn = true;
    }


}
