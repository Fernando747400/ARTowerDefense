using System.Collections;
using UnityEngine;

public class Enemy_Jump : Enemy
{
    [SerializeField] float jumpForce;
    [SerializeField] float jumpDelay;

    //Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        StartCoroutine(CorJump());

    }
    private IEnumerator CorJump()
    {
        while (true)
        {
            Jump();
            // Debug.Log("jumped");
            yield return new WaitForSeconds(jumpDelay);
            
        }
    }
    private void Jump()
    {
        Vector3 jumpDir = Vector3.up * jumpForce;
        rb.AddForce(jumpDir);
        
    }
}
