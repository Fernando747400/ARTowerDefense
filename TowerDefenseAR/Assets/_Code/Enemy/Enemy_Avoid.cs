using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Avoid : Enemy
{
    [SerializeField] private float avoidanceStrength;
    private RaycastHit[] hits;

    // Update is called once per frame
    protected override void Update()
    {
        Move();
    }
    protected override void Move()
    {
        if (rb.velocity.magnitude >= maxSpeed)
        {
            Vector3 steering = Seek(target.transform.position);
            Vector3 limitingForce = steering * -1;
            rb.AddForce((steering + limitingForce) * speed);
        }
        else
        {
            Vector3 steering = Seek(target.transform.position);
            rb.AddForce(steering * speed);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Obstacle")) return;
        Vector3 avoidanceVector = AvoidObstacles(other.transform.position);
        rb.AddForce(avoidanceVector * avoidanceStrength);
    }

    void CheckVision()
    {
        
        
    }
    private void Vision()
    {
        // hits = Physics.BoxCastAll(Vector3.forward * 10,Vector3.one*5f,Vector3.forward);
        // Queue<RaycastHit> listHits = hits.toList();
        // foreach (var hit in hits)
        // {
        //     if (!hits.Contains(listHits[])) return;
        //
        // }
        
    }
}
