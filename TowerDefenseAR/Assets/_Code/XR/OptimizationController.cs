using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizationController : MonoBehaviour
{
    public int TargetWidth;
    public int TargetHeight;
    private void Awake()
    {
        Application.targetFrameRate = 30;
        Screen.SetResolution(TargetWidth,TargetHeight, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
