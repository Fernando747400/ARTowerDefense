using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaneController_CodeXR : MonoBehaviour
{
    
    public List<ARPlane> arPlanes;
    public ARPlaneManager planeManager;
    // public Text reference; 
    [SerializeField] private Text textPlanes;

    private void Start()
    {

    }

    private void Update()
    {
        // if(arPlanes!=null)
         // reference.text = "planes arPlanes = " + arPlanes.Count;
    }

    private void OnEnable()
    {
        arPlanes = new List<ARPlane>();
        planeManager.planesChanged += HandlePlaneDetection;
    }
    
    void HandlePlaneDetection(ARPlanesChangedEventArgs args)
    {
        if (PlanesChecker) return;

        if (args.added != null && args.added.Count > 0)
        {
            if(arPlanes!=null) arPlanes.AddRange(args.added);
        }
    }

    private bool PlanesChecker
    {
        get
        {
            if (arPlanes != null)
                if (arPlanes.Count >= 1)
                {
                    planeManager.enabled = false;
                    textPlanes.text = "Plane = " + planeManager.enabled;
                    return true;
                }

            return false;
        }
    }

    public  void ClearPlanesList()
    {
        planeManager.enabled = false;

        if(arPlanes!= null) 
            if (arPlanes.Count > 0)
            {
                for (int i = 0; i < arPlanes.Count; i++)
                {
                    arPlanes.Remove(arPlanes[i]);
                }
            }
        
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

       
    }


    public void HandlePlaneManager(bool active)
    {
        if (planeManager.enabled)
        {
            active = !active;
        }

        planeManager.enabled = active;
        textPlanes.text = "Plane = " + planeManager.enabled;

    }
    
    
}
