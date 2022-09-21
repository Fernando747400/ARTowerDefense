using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Dependencies")]
    public int maxBounceEnemy;
    public List<GameObject> enemies;
    public GameObject rPoint;
    public int damage;

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
        this.enemies.Capacity = maxBounceEnemy;
    }

    private void Update()
    {
        this.enemies.Capacity = maxBounceEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            index = index + 1;

            if (index < this.enemies.Capacity)
            {
                this.enemies.Insert(index, other.gameObject);
                line.positionCount = this.enemies.Count;
                foreach (var item in this.enemies)
                {
                    line.SetPosition(this.enemies.Count - 1, item.transform.position);
                    Debug.Log(this.enemies.Count - 1, item);
                    followTarget.Target = this.enemies[1];
                    item.GetComponent<DummyEnemy>().live--;
                }
            }

            StartCoroutine(UpdateShoot());
        }
        
    }

    void AddLaser()
    {
        index = index + 1;
        this.enemies.Insert(index, this.gameObject);
        line.positionCount = this.enemies.Count;

        foreach (var item in this.enemies)
        {
            line.SetPosition(this.enemies.Count -1, item.transform.position);
            Debug.Log(this.enemies.Count -1, item);
        }
    }

    private IEnumerator UpdateShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            sphere.enabled = false;
            this.enemies.Clear();
            index = -1;
            AddLaser();
            rPoint.transform.rotation = followTarget.FinalRotation;
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
