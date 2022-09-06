using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_cannon : MonoBehaviour
{
    public float Speed;
    public GameObject Target;
    public Vector3 Direction;

    private Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Direction * Speed * 100f * Time.deltaTime,ForceMode.Force);
    }
}
