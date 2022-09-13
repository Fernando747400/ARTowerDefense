using System.Collections;
using UnityEngine;

public class Enemy_Jump : Enemy
{
    [SerializeField] float jumpForce;

    //Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        StartCoroutine(corJump());

    }
    IEnumerator corJump()
    {
        while (true)
        {
            Jump();
            // Debug.Log("jumped");
            yield return new WaitForSeconds(2);
            
        }
    }
    void Jump()
    {
        Vector3 jumpDir = Vector3.up * jumpForce;
        rb.AddForce(jumpDir);
        
    }

}
