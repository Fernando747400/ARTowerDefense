using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SteeringBehaviours : MonoBehaviour
{

    //direction in which the enemy is moving.

    [HideInInspector] public Vector3 currentVector;

    [SerializeField] GameObject target;
    [SerializeField] private float speed;
    [SerializeField] string behaviour;
    [SerializeField] float avoidanceStrength;
    [HideInInspector] public Rigidbody rb;
    int layerMask;
    List<Collider> obstaclesList = new List<Collider>();

    // Start is called before the first frame update
    public virtual void Start()
    {
        Prepare();
        StartCoroutine(Tick());
        layerMask =~ LayerMask.GetMask("Enemy");

    }
    // Update is called once per frame
    public virtual void Update()
    {
        Move();
        bool isEmpty = !obstaclesList.Any();
        if(isEmpty)
        {
            for (int i = 0; i < obstaclesList.Count; i++)
            {
                Debug.Log(obstaclesList[i]);
            }
        }
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
        Vector3 temp;;
        

        for (int i = 0; i < obstaclesList.Count; i++)
        {
            temp = obstaclesList[i].transform.position;
        }
        Vector3 avoidanceVector = transform.position - obstaclesList[0].transform.position; 

        Vector3 result = Vector3.Normalize(distanceVector + steeringForce + avoidanceVector);
        return result;

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
        Vector3 steering;

        switch (behaviour)
        {
            // case "avoid":
            // steering = Avoid(target.transform.position);
            // transform.position += (currentVector + steering * speed) * Time.fixedDeltaTime;
            // break;

            default:
            steering = Seek(target.transform.position);
            Vector3 resultingVector = (currentVector + steering * speed);
            rb.AddForce (resultingVector);
            break;
        }
        //speed = Arrival(target.transform.position);

    }
    void ReCast()
    {
        Collider[] obstacles = Physics.OverlapSphere(transform.position,2,layerMask);

        if(obstacles.Length != 0)
        {
            behaviour = "avoid";

        }else
        {
            behaviour = "seek";
        }
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (! obstaclesList.Contains(obstacles[i]))
            {
                obstaclesList.Add(obstacles[i]);
                // Debug.Log("Added " + obstacles[i].name + " to list.");
                
            }
            
        }
        
    }

    void Prepare()
    {
        if (rb == null)
        {
            try
            {
                rb = gameObject.GetComponent<Rigidbody>();
            }
            catch{Debug.LogWarning("Could not find RigidBody");}
        }

    }

}