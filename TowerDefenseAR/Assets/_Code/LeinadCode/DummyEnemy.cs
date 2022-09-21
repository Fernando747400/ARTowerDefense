using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    public float live;

    void Update()
    {
        if(live <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
