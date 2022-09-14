using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    
    public List<ARPlane> arPlanes;
    public ARPlaneManager planeManager;
    public Text reference; 
    public Text reference2; 
    public Text reference3; 
    [SerializeField] private Text textPlanes;

    private ARPlanesChangedEventArgs eventsPlanes;
    private void Start()
    {

    }

    private void Update()
    {
        if (eventsPlanes != null)
        {
            reference.text = "planes added = " + eventsPlanes.added.Count;
            reference2.text = "planes Update = " + eventsPlanes.updated.Count;
        }
        reference2.text = "planes arPlanes = " + arPlanes.Count;
    }

    private void OnEnable()
    {
        arPlanes = new List<ARPlane>();
        planeManager.planesChanged += HandlePlaneDetection;
    }

    void HandlePlaneDetection(ARPlanesChangedEventArgs args)
    {
        eventsPlanes = args;

        // if(args.updated != null)
        // {
        //     reference.text = "planes in scene = " + arPlanes.Count;
        // }

        if (arPlanes.Count >= 1)
        {
            planeManager.enabled = false; 
            textPlanes.text = "Plane = "+ planeManager.enabled;
            return;
        }

        if (args.added != null && args.added.Count > 0)
            arPlanes.AddRange(args.added);
    }

    public  void ClearPlanesList()
    {
        if (arPlanes.Count >= 0)
        {
            for (int i = 0; i < arPlanes.Count; i++)
            {
                arPlanes.Remove(arPlanes[i]);
                Destroy(arPlanes[i].gameObject);
            }
        }

        if (eventsPlanes.added.Count >= 0)
        {
            for (int i = 0; i < eventsPlanes.added.Count; i++)
            {
                eventsPlanes.added.Remove(eventsPlanes.added[i]);
                Destroy(eventsPlanes.added[i].gameObject);
            }    
        }

        if (eventsPlanes.updated.Count >= 0)
        {
            for (int i = 0; i < eventsPlanes.updated.Count; i++)
            {
                eventsPlanes.updated.Remove(eventsPlanes.updated[i]);
                Destroy(eventsPlanes.updated[i].gameObject);
            }   
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
