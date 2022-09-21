using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefabOne;
    public GameObject enemyPrefabTwo;

    private void Start()
    {
        StartCoroutine(TimeForSpawn());
    }

    public void Spawn()
    {
        float RandomNum = Random.Range(1, 2);
        if (RandomNum == 1)
        {
            GameObject.Instantiate(enemyPrefabOne);
        }
        if (RandomNum == 2)
        {
            GameObject.Instantiate(enemyPrefabTwo);
        }
    }

    IEnumerator TimeForSpawn()
    {
        float RandomTime = Random.Range(10, 20);
        yield return new WaitForSeconds(RandomTime);
        Spawn();
    }
}

