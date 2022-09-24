using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    
    [SerializeField] private GameObject resetPlanesButton;
    [SerializeField] private GameObject generatePlanesButton;
    [SerializeField] private GameObject startButton;

    [SerializeField] private Text countDown;
    [SerializeField] private Text text_Healt;
    [SerializeField] private string sceneName;

    [Header("Pool")] 
    [SerializeField] private GameObject poolPrefab;
    [SerializeField] private int numberOfPools;
    [SerializeField] private float radius = 1;
    [SerializeField] private float angleToSpawn;

    [SerializeField] private GameObject[] poolersGO;
    [SerializeField] private ObjectPooler[] poolers;

    [SerializeField] private GameObject[] spawnersGO;
    [SerializeField] private Spawner[] spawners;

    [SerializeField]private EnemyPoolingManager enemyPoolingManager;
    private GameObject _centerGameObject;


    private void Start()
    {
        countDown.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (TowerDamage.Instance)
        {
            text_Healt.text = "Center Life: " +   TowerDamage.Instance.CenterHealth;
        }

    }

    public void StartGame()
    {
        if (CanStartGame())
        {
            // print("game start");
            startButton.SetActive(false);
            // resetPlanesButton.SetActive(false);
            generatePlanesButton.SetActive(false);
            StartCoroutine(CountDown());
        }
    }
    
    public void CallFinishedGame()
    {
        print("Call finished game");
        countDown.gameObject.SetActive(true);
        countDown.text = "Game Finished";
        StartCoroutine(FinalCountDown());
    }


    bool CanStartGame()
    {
       _centerGameObject = GameObject.FindWithTag("CenterPrefab");
        GameObject turret = GameObject.FindWithTag("TrackedImage");

        if (_centerGameObject != null && turret!=null)  return true;
        
        return false;
    }

    IEnumerator CountDown()
    {
        countDown.gameObject.SetActive(true);
        countDown.text = "Ready";
        yield return new WaitForSeconds(2f);
        countDown.text = "Go";
        yield return new WaitForSeconds(1f);
        countDown.gameObject.SetActive(false);

        print("enemies salen");
        enemyPoolingManager.BeginGame = true;
       
        //SpawnPools();

    }

    // private void SpawnPools()
    // {
    //     poolersGO = GameObject.FindGameObjectsWithTag("Pooler");
    //     spawnersGO = GameObject.FindGameObjectsWithTag("Spawner");

       

    //     for (int i = 0; i < poolersGO.Length; i++)
    //     {
    //         ObjectPooler obj = poolersGO[i].GetComponent<ObjectPooler>();
    //         obj.StartPools();
           
    //     }
    //     for (int i = 0; i < spawnersGO.Length; i++)
    //     {
    //          Spawner spawn = spawnersGO[i].GetComponent<Spawner>();
    //         spawn.SpawnerStart();
    //     }

        
        

    // }
    IEnumerator FinalCountDown()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }
    
    // #region Editor
    //
    // public void CallGameFinished()
    // {
    //     CallFinishedGame();
    // }
    //

    // #endregion
    
    
}

// [CustomEditor((typeof(GameplayController)))]
// public class GamepayEditor : Editor
// {
    // public override void OnInspectorGUI()
    // {
        // DrawDefaultInspector();
        // GameplayController gameplayController = target as GameplayController;

        // if (GUILayout.Button("CALL FINAL GAME"))
        // {
            // gameplayController.CallGameFinished();
            
        // }
// }
// }