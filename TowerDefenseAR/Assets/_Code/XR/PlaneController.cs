using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    
    public List<ARPlane> arPlanes;
    public Spawner_UI_Controller uiController;
    public ARPlaneManager planeManager;
    public Text reference; 

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        arPlanes = new List<ARPlane>();
        planeManager.planesChanged += HandlePlaneDetection;

        uiController.OnActivatePlaneGenerator += HandlePlaneManager;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void HandlePlaneDetection(ARPlanesChangedEventArgs args)
    {
        if(args.updated != null)
        {
            reference.text = arPlanes.Count.ToString();
        }
        
        if(arPlanes.Count <= 1) return;
        
        if (args.added != null && args.added.Count > 0)
            arPlanes.AddRange(args.added);
    }

    void ClearPlanesList()
    {
        arPlanes = new List<ARPlane>();
    }


    void HandlePlaneManager(bool active)
    {
        planeManager.enabled = active;
        ClearPlanesList();
    }
    
    
    
}
