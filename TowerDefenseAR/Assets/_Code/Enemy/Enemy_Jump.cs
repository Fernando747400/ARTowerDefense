using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Jump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float gravForce;
    SteeringBehaviours behaviours;

    private Vector3 dir;

    // Start is called before the first frame update
    // void Start()
    // {
    //     StartCoroutine(corJump());
    //     if (behaviours == null)
    //     {
    //         try
    //         {
    //             behaviours = gameObject.GetComponent<SteeringBehaviours>();
    //         }
    //         catch{Debug.LogWarning("Could not find SteeringBehaviours");}
    //     }
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Gravity();

    // }

    // void Jump()
    // {
    //     Vector3 jumpDir = new Vector3(dir.x, jumpForce, dir.z);
    //     dir = jumpDir * Time.fixedDeltaTime;
    //     Debug.Log("jump done");
    // }
    // IEnumerator corJump()
    // {
    //     while (true)
    //     {
    //         Jump();
    //         yield return new WaitForSeconds(5);
            
    //     }
    // }

    // void Gravity()
    // {
    //     Vector3 gVector = new Vector3(0,-gravForce,0);
    //     if (transform.position.y > 0.5f)
    //     {
    //         transform.position -= gVector * Time.fixedDeltaTime;
    //     }

    // }

}
