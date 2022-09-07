using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Jump : SteeringBehaviours
{
    [SerializeField] float jumpForce;
    [SerializeField] float gravForce;
    SteeringBehaviours behaviours;
    Coroutine jumpCor;

    //Start is called before the first frame update
    public override void Start()
    { 
        base.Start();
        StartCoroutine(corJump());
        //jumpCor = StartCoroutine(corJump());

    }

    public override void Update()
    {
        base.Update();
        //Gravity();
    }

    IEnumerator corJump()
    {
        while (true)
        {
            Jump();
            Debug.Log("jumped");
            yield return new WaitForSeconds(2);
            
        }
    }
    void Jump()
    {
        Vector3 jumpDir = Vector3.up * jumpForce;
        rb.AddForce(jumpDir);

        // if (transform.position.y == 0.5f)
        // {    
        //     currentVector += jumpDir;
        //     Debug.Log("jumped");
        //     StopCoroutine(jumpCor);
        //     // StartCoroutine(corJump());
        // }
    }

    // void Gravity()
    // {
    //     Vector3 gVector = Vector3.up * jumpForce;
    //     if (transform.position.y > 0.5f)
    //     {
    //         Debug.Log("airborne"+gVector * Time.fixedDeltaTime);
    //         transform.position -= gVector * Time.fixedDeltaTime;
    //     }

    // }

}
