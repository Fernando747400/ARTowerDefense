using System.Collections;
using UnityEngine;

public class TowerDamage : MonoBehaviour
{
    public float hp;
    public GameObject controller;
    public GameplayController gameplayController;

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
            Destroy(other.gameObject);
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
