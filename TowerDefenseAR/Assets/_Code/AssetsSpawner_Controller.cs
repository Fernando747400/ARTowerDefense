using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class AssetsSpawner_Controller : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _prefabToSpawn;

    private List<GameObject> spawnedObjects;
    public ARRaycastManager raycastManager;
    List<ARRaycastHit> rayHits;
    private BoundedPlane _boundedPlane;
    private void Start()
    {
        // raycastManager = GetComponent<ARRaycastManager>();
       
    }

    private void OnEnable()
    {
        Spawner_UI_Controller spawnerUIController = GetComponent<Spawner_UI_Controller>();
        spawnerUIController.OnChangePrefab += HandleAssetPrefab;
    }

    private void HandleAssetPrefab(GameObject prefab)
    {
        _prefabToSpawn = prefab;
    }

    private void Update()
    {
        if (!GetTouch(out Vector2 touchPosition))
        {
            return;
        }

        if(raycastManager.Raycast(touchPosition, rayHits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = rayHits[0].pose;
            spawnedObjects.Add(Instantiate(_prefabToSpawn, hitPos.position, hitPos.rotation));
        }
    }

    private bool GetTouch(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }
}