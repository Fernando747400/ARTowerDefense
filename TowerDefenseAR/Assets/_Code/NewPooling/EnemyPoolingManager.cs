using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolingManager : MonoBehaviour
{
   [SerializeField] public List<GameObject> Spawners;
   public GameObject TankPrefab;
   public GameObject JumpingPrefab;
   public int enemiesToSpawn; 
   public bool BeginGame = false;

 private int currentCount;
   private float waitTime = 3f;
   private float currentTime = 0f;

   void Update()
   {
    if (! BeginGame)return;
    Debug.Log("Spawner count " + Spawners.Count);
    if (Spawners.Count != 0){
        if(currentCount <= enemiesToSpawn){
        SpawnEnemies();
       } 
    } else {
        FindPools();
    }
       
    
   }

   private void FindPools(){
        GameObject[] poolList = GameObject.FindGameObjectsWithTag("Pooler");
        Debug.Log("Finding pools " + poolList);
       foreach(var item in poolList){
        Spawners.Add(item);
       }
   }


   private void SpawnEnemies(){

    if (currentTime > waitTime){
        currentTime = 0f;
        GameObject temp = null;
    float selected = Random.Range(0,2);
    if (selected == 1)  temp = TankPrefab;
    else if (selected == 0) temp = JumpingPrefab;

    GameObject enemy = Instantiate(temp, Spawners[Random.Range(0, Spawners.Count)].gameObject.transform.position, Quaternion.identity);
    currentCount ++;
    }  
    currentTime += Time.deltaTime; 
   }
}
