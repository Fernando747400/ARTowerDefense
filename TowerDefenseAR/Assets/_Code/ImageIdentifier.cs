using System;
using System.Collections;
using System.Collections.Generic;
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
        
        _gameObjects.Add(GameObject.FindGameObjectWithTag("TrackedImage"));
        reference.text = "Add obj to list";

        foreach (var item in args.added)
        {
            
            switch (item.referenceImage.name)
            {
                case "Tower":
                    foreach (var obj in _gameObjects)
                    {
                        if (obj.name == "Tower")
                        {
                            reference.text = obj.name;
                            PositionsController pos = obj.GetComponent<PositionsController>();
                            pos.RePostionGO(item);
                        }
                    }
                    break;
             
                case "Lasser":
                    foreach (var obj in _gameObjects)
                    {
                        if (obj.name == "Lasser")
                        {
                            reference.text = obj.name;

                            PositionsController pos = obj.GetComponent<PositionsController>();
                            pos.RePostionGO(item);
                        }
                    }
                    
                    break;
                
                case "Center":
                    foreach (var obj in _gameObjects)
                    {
                        if (obj.name == "Center")
                        {
                            reference.text = obj.name;
                            PositionsController pos = obj.GetComponent<PositionsController>();
                            pos.RePostionGO(item);
                        }
                    }
                    
                    break;

                
            }
             
        }
    
    }
}
