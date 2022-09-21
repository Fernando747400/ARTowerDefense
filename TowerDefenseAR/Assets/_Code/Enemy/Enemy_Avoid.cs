using System.Collections.Generic;
using UnityEngine;

public class Enemy_Avoid : Enemy
{
    [SerializeField] private float avoidanceStrength;
    private RaycastHit[] hits;
    [SerializeField] private float visionDistance = 1f;
    private LayerMask _layerMask;
    private bool _detected;
    private Vector3 steering = new Vector3(0f, 0f, 0f);
    private Vector3 limitingForce = new Vector3(0f, 0f, 0f);

    public override void Start()
    {
        base.Start();
        Prepare();

    }
    // Update is called once per frame
    protected override void Update()
    {
        Move();
        Vision();
        Debug.Log(_detected);
    }
    protected override void Move()
    {
        if (rb.velocity.magnitude >= maxSpeed)
        {
            switch (_detected)
            {
                case false:
                steering = Seek(target.transform.position);
                steering = limitingForce = steering * -1;
                rb.AddForce((steering + limitingForce) * speed);
                    break;
                case true:
                    steering = (AvoidObstacles(target.transform.position));
                    steering += Seek(target.transform.position);
                limitingForce = steering * -1;
                rb.AddForce((steering + limitingForce) * speed);
                    break;
            }
        }
        else
        {
            switch (_detected)
            {
                case false:
                steering = Seek(target.transform.position);
                rb.AddForce(steering * speed);
                    break;
                case true:
                    steering = (AvoidObstacles(target.transform.position));
                    steering += Seek(target.transform.position);
                    rb.AddForce(steering * speed);
                    break;
            }
        }
    }
    private void Vision()
    {
        _detected = Physics.BoxCast(transform.position, transform.lossyScale * 4f,
            transform.forward, Quaternion.identity, visionDistance,_layerMask);
        // if (hits.Length == 0) return;
        // List <RaycastHit> hitsList = hits.ToList();
        // foreach (var i in hitsList)
        // {
        //     if (hits.Contains(i)) return;
        //     hitsList.Remove(i);
        // }
        //
        // if (hitsList.Any())
        // {
        //     _detected = true;
        // }
        // else
        // {
        //     _detected = false;
        // }
    }
    protected override void Prepare()
    {
        base.Prepare();
        _layerMask =~ LayerMask.GetMask("Enemy");
    }
}
