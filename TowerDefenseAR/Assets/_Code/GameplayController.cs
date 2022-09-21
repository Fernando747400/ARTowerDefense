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
    [SerializeField] private string sceneName;


    private void Start()
    {
        countDown.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        if (CanStartGame())
        {
            // print("game start");
            startButton.SetActive(false);
            resetPlanesButton.SetActive(false);
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
        GameObject centerGameObject = GameObject.FindWithTag("CenterPrefab");
        GameObject turret = GameObject.FindWithTag("TrackedImage");

        if (centerGameObject != null && turret!=null)  return true;
        
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

    }

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