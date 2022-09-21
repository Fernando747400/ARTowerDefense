using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_cannon : MonoBehaviour
{
    public float Speed;
    public GameObject Target;
    public Vector3 Direction;

    public ParticleSystem Explosion;

    private Rigidbody rb;
    private Vector3 initialPos;
    private bool hitSucc;
    private float timer;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPos = this.transform.position;
        hitSucc = false;
        timer = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Floor"))
        {
            HitEnemies();
        }
    }

    private void HitEnemies()
    {
        RaycastHit[] rayHits = Physics.SphereCastAll(this.transform.position, 1f, this.transform.forward, 1f);
        foreach (var item in rayHits)
        {
            DummyEnemy enemy = item.transform.gameObject.GetComponent<DummyEnemy>();
            if(enemy != null)
            {
                enemy.live -= 2f;
                hitSucc = true;
            }
        }
        if (hitSucc) DestroyBullet();
    }

    private void FixedUpdate()
    {
        
        timer += Time.deltaTime;

        if(timer >= 15f)
        {
            DestroyBullet();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 1f);
    }

    private void DestroyBullet()
    {
        Instantiate(Explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
