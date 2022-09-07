using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _looker;
    [SerializeField] private GameObject _target;

    [Header("Dependencies")]
    [SerializeField] private bool _ignoreX;
    [SerializeField] private bool _ignoreY;
    [SerializeField] private bool _ignoreZ;

    public void Start()
    {
        if (_looker == null) _looker = this.gameObject;
        if (_target == null) _target = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), Vector3.zero, Quaternion.identity);
    }

    public void Update()
    {
        
    }

    private void LookAt()
    {

    }

    private void IgnoreAxis(Vector3 rotationValues)
    {

    }
}
