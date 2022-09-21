using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_look_forward : MonoBehaviour
{
    private Rigidbody _parentRb;
    // Start is called before the first frame update
    void Start()
    {
        if (_parentRb != null) return;
        try
        {
            _parentRb = GetComponentInParent<Rigidbody>();
        }
        catch {Debug.LogWarning("could not find parentRB"); }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_parentRb.velocity *100f);
    }
}
