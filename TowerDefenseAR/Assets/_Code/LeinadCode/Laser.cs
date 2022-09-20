using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Dependencies")]
    public int maxBounceEnemy;
    public List<GameObject> enemies;
    public GameObject rPoint;

    [Header("Follow")]
    [SerializeField] private FollowTarget followTarget;
    private LineRenderer line; 
    private int index = -1;
    private SphereCollider sphere;
    
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
        line = GetComponent<LineRenderer>();
        AddLaser();
    }

    private void Update()
    {
        rPoint.transform.rotation = followTarget.FinalRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy") return; 
        
        enemies.Capacity = maxBounceEnemy;
        index = index + 1;

        if(index > enemies.Capacity) return;

        enemies.Insert(index, other.gameObject);
        line.positionCount = enemies.Count;
        foreach (var item in enemies)
        {
            line.SetPosition(enemies.Count - 1, item.transform.position);
            Debug.Log(enemies.Count - 1, item);
            followTarget.Target = enemies[1];
        }
        StartCoroutine(UpdateShoot());
    }

    void AddLaser()
    {
        index = index + 1;
        enemies.Insert(index, this.gameObject);
        line.positionCount = enemies.Count;

        foreach (var item in enemies)
        {
            line.SetPosition(enemies.Count -1, item.transform.position);
            Debug.Log(enemies.Count -1, item);
        }
    }
    private IEnumerator UpdateShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            sphere.enabled = false;
            enemies.Clear();
            index = -1;
            AddLaser();
            StartCoroutine(CanShoot());
        }
    }
    
    private IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(2);
        sphere.enabled = true;
        StopAllCoroutines();
    }
    
}
