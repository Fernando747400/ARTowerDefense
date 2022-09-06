using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] private float speed;
    //direction in which the enemy is moving.
    Vector3 currentVector;
    int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tick());
        layerMask =~ LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    
    Vector3 Seek(Vector3 targetPos)
    {
        //moves towards target
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;
    }

    Vector3 Flee(Vector3 targetPos)
    {
        //moves away from target
        Vector3 distanceVector = transform.position - targetPos;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;

    }

    float Arrival(Vector3 targetPos)
    {
        //seeks target and chages velocity depending on distance
        float result;
        Vector3 distanceVector = targetPos - transform.position;
        switch (distanceVector.magnitude)
        {
            case > 10f:
                result = 0f;
                break;

            // case < 10f:
            //     result = 1f;
            //     break;
            // case < 5f:
            //     result = .6f;
            //     break;
            // case < .1f:
            //     result = 0f;
            //     break;

            default:
                result = 1f;
                break; 

        }
        Debug.Log(result);
        return result;
    }

    Vector3 Avoid(Vector3 targetPos)
    {
        //seeks target while avoiding obstacles
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;

    }
    void ReCast()
    {
        Collider[] obstacles = Physics.OverlapSphere(transform.position,1,layerMask);
        Queue obstaclesQ = new Queue();
        if (obstacles.Length > 0)
        {
            foreach (Collider obstacle in obstacles)
            {
                obstaclesQ.Enqueue(obstacle);

            }


        }
    }

    IEnumerator Tick()
    {
        while(true)
        {
            ReCast();
            yield return new WaitForSeconds(.33f);


        }
    }
    

    void Move()
    {
        Vector3 steering = Avoid(target.transform.position);
        //speed = Arrival(target.transform.position);
        transform.position += (currentVector + steering * speed) * Time.fixedDeltaTime;

    }
}