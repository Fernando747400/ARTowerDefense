using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer line;
    public List<GameObject> enemies;
    public string objectToAdd;
    int index = -1;

    //public Queue enemies = new Queue();

    void Start()
    {
        line = GetComponent<LineRenderer>();
        objectToAdd = "LaserBeam";
        AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Colisiona");

            objectToAdd = "Enemy";
            index = index + 1;
            enemies.Insert(index, other.gameObject);
            line.positionCount = enemies.Count;

            foreach (var item in enemies)
            {
                line.SetPosition(enemies.Count - 1, item.transform.position);
                Debug.Log(enemies.Count - 1, item);
            }
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Colisiona");

            objectToAdd = "Enemy";
            index = index + 1;
            enemies.Insert(index, other.gameObject);
            line.positionCount = enemies.Count;

            foreach (var item in enemies)
            {
                line.SetPosition(enemies.Count - 1, item.transform.position);
                Debug.Log(enemies.Count - 1, item);
            }
        } 
    }
    */

    private void OnTriggerExit(Collider other)
    {

    }

    void AddEnemy()
    {
        index = index + 1;
        enemies.Insert(index, GameObject.FindGameObjectWithTag(objectToAdd));
        line.positionCount = enemies.Count;

        foreach (var item in enemies)
        {
            line.SetPosition(enemies.Count -1, item.transform.position);
            Debug.Log(enemies.Count -1, item);
        }
    }
}
