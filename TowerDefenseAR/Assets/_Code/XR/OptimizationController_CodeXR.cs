using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizationController_CodeXR : MonoBehaviour
{
    public int TargetWidth;
    public int TargetHeight;
    private void Awake()
    {
        Application.targetFrameRate = 30;
        Screen.SetResolution(TargetWidth,TargetHeight, true);
    }
    
}
