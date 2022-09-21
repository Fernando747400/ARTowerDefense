using UnityEngine;

public class Enemy : SteeringBehaviours
{
    public float maxSpeed = 2f;
    [HideInInspector]public Rigidbody rb;
    public virtual void Start()
    {
        Prepare();
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        if (rb.velocity.magnitude >= maxSpeed)
        {
            Vector3 steering  = Seek(target.transform.position);
            Vector3 limitingForce = steering * -1;
            rb.AddForce((steering +limitingForce) * speed);
        }
        else
        {
            Vector3 steering  = Seek(target.transform.position);
            rb.AddForce(steering * speed);
        }
    }
    protected virtual void Prepare()
    {
        if (rb != null) return;
        try
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        catch { Debug.LogWarning("Could not find RigidBody"); }
    }
}
