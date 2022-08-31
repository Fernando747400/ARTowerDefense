using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
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

        foreach (var item in args.added)
        {
            
            switch (item.referenceImage.name)
            {
                case "Tower":
                    foreach (var obj in _gameObjects)
                    {
                        if (obj.name == "Tower")
                        {
                            PositionsController pos = obj.GetComponent<PositionsController>();
                            pos.RePostionGO(item);
                        }
                    }
                    
                break;
             // case "imagen 2":
            // animalPrefab = spawnedPrefabs["imagen 2"];
            // animalPrefab.transform.position = trackedImage.transform.position;
            // animalPrefab.SetActive(true);
            // break;
            }
             
        }
    
    }
}
