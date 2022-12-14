using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageIdentifier : MonoBehaviour
{
    public List<GameObject> _gameObjects;
    public Text reference; 
    
    private ARTrackedImageManager _TrackerManager;
    

    private void Awake()
    {
        _TrackerManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _TrackerManager.trackedImagesChanged += UpdatedImage;
    }

    private void OnDisable()
    {
        _TrackerManager.trackedImagesChanged -= UpdatedImage;
    }

    
    private void UpdatedImage(ARTrackedImagesChangedEventArgs args)
    {
         GameObject gameObject =GameObject.FindGameObjectWithTag("TrackedImage") ;
        _gameObjects.Add(gameObject);
        // reference.text = "Add obj to list" + gameObject.name;

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            switch (trackedImage.referenceImage.name)
            {
                // case "Tower":
                //     foreach (var obj in _gameObjects)
                //     {
                //         if (obj.name == "Tower")
                //         {
                //             reference.text =" Mover Game Objetc = " +obj.name;
                //             PositionsController pos = obj.GetComponent<PositionsController>();
                //             pos.RePostionGO(item);
                //         }
                //     }
                //     break;
                //
                // case "Laser":
                //     foreach (var obj in _gameObjects)
                //     {
                //         if (obj.name == "Laser")
                //         {
                //             reference.text = " Mover Game Objetc = " +obj.name;
                //
                //             PositionsController pos = obj.GetComponent<PositionsController>();
                //             pos.RePostionGO(item);
                //         }
                //     }
                //     
                //     break;
                
                // case "Center":
                //     foreach (var obj in _gameObjects)
                //     {
                //         if (obj.name == "Center")
                //         {
                //             reference.text = " Mover Game Objetc = " +obj.name + " pos= "+ trackedImage.transform.position;
                //             PositionsController pos = obj.GetComponent<PositionsController>();
                //             //pos.RePostionGO(trackedImage, reference);
                //         }
                //     }
                //     
                //     break;

                
            }
             
        }
    
    }
}
