using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] private float speed;
    Vector3 currentVector;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tick());
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
        Collider[] obstacles = Physics.OverlapSphere(transform.position,2,0);
        if (obstacles != null)
        {
            
            Debug.Log("Contact");
        }

    }

    IEnumerator Tick()
    {
        ReCast();
        yield return new WaitForSeconds(.5f);
    }
    

    void Move()
    {

        Vector3 steering = Avoid(target.transform.position);
        //speed = Arrival(target.transform.position);
        transform.position += (currentVector + steering * speed) * Time.fixedDeltaTime;

    }
}