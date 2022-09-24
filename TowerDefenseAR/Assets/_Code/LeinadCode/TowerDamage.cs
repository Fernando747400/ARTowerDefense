using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerDamage : MonoBehaviour
{
    public static TowerDamage Instance;
    public float hp;
    public GameObject controller;
    public GameplayController gameplayController;

    public float CenterHealth
    {
        get => hp;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        controller = GameObject.Find("GameplayControllers");
        gameplayController = controller.GetComponent<GameplayController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            CheckHealt();
            Debug.Log("Colisionando");
            StartCoroutine(GetDamage());
            other.GetComponent<DummyEnemy>().RestartPool();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(GetDamage());   
    }

    IEnumerator GetDamage()
    {
        yield return new WaitForSeconds(3);
        hp--;
        StopCoroutine(GetDamage());
    }

    public bool CheckHealt()
    {
        if (hp <= 0)
        {
            gameplayController.CallFinishedGame();
            return true; 
        }
        return false;
    }
}
