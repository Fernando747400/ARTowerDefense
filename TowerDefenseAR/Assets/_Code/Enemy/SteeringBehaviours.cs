using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringBehaviours : MonoBehaviour
{
    public float speed;
    [HideInInspector]public Vector3 currentVector;
    public GameObject target;
    
    //SteeringBehaviours always returns a normalized vector
    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;
    }
    protected Vector3 Flee(Vector3 targetPos)
    {
        Vector3 result = Seek(targetPos) * -1;
        return result;
    }
    protected float Arrival(Vector3 targetPos)
    {
        float result;
        Vector3 distanceVector = targetPos - transform.position;
        switch (distanceVector.magnitude)
        {
            case float n when(n > 30f):
                result = 0f;
                break;

            case float n when(n < 30f && n > 20f):
                 result = 3f;
                 break;

            case float n when (n < 20 && n > 10):
                result = 2f;
                break;
            
            case float n when (n < 10 && n > 0):
                result = .33f;
                break;

            default:
                result = 0f;
                break; 
        }
        return result;
    }
    protected Vector3 AvoidObstacles(Vector3 obstaclePos)
    {
        Vector3 distanceVector = obstaclePos - transform.position;
        Vector3 avoidanceVector = Vector3.Cross(Vector3.up, distanceVector);
        Vector3 result = Vector3.Normalize(avoidanceVector);
        return result;
    }

    // public Vector3 pursuit(Vector3 targePos)
    // {
    //     
    //     
    // }
    
    // Wandering behaviour shelved for now
    // public Vector3 Wander(Vector3 targetPos)
    // {
    //     Vector3 distanceVector = targetPos - transform.position;
    //     Vector3 steeringForce = distanceVector + currentVector;
    //
    //     Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
    //     return result;
    //
    //
    // }
    // public void RandomizeTarget()
    // {
    //     for (int i = 0; i < 2; i++)
    //     {
    //         float r = Random.Range(10,40);
    //         Vector3 randomTarget = new Vector3 (r,r,r);
    //         Debug.Log("Randomized to: " + randomTarget.x +randomTarget.y + randomTarget.z);
    //     }
    //
    // }
    //
    // public IEnumerator CorRandomize()
    // {
    //     while (true)
    //     {
    //         RandomizeTarget();
    //         yield return new WaitForSeconds(2);
    //     }
    // }
    
}