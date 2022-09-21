using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GameObject resetPlanesButton;
    [SerializeField] private GameObject generatePlanesButton;
    [SerializeField] private GameObject startButton;

    [SerializeField] private Text countDown;


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
    
}
