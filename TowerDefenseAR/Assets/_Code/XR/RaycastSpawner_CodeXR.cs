using System;
using System.Collections;
using System.Collections.Generic;
using _Code.XR;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class RaycastSpawner_CodeXR : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _prefabToSpawn;

    private List<GameObject> spawnedObjects;
    public ARRaycastManager raycastManager;
    List<ARRaycastHit> rayHits;
    private BoundedPlane _boundedPlane;

    private int maxPrefabs;
    private TorretTypes currentType;
    private void Start()
    {
        // raycastManager = GetComponent<ARRaycastManager>();
        rayHits = new List<ARRaycastHit>();

    }

    private void OnEnable()
    {
        SpawnerUI_CodeXR spawnerUICodeXR = GetComponent<SpawnerUI_CodeXR>();
        spawnerUICodeXR.OnChangePrefab += HandleAssetPrefab;
    }

    private void HandleAssetPrefab(GameObject prefab)
    {
        _prefabToSpawn = prefab;
        
    }

    private void Update()
    {
        if (GetTouch(out Vector2 touchPosition))
        {
            if (raycastManager != null)
            {
                if(raycastManager.Raycast(touchPosition, rayHits, TrackableType.PlaneWithinPolygon))
                {
                    var hit = rayHits[0];
                    HandleRaycast(hit);
                }
            }
        }
    }

    void HandleRaycast(ARRaycastHit hit)
    {
        if (hit.trackable is ARPlane plane)
        {
            if (plane.gameObject.activeInHierarchy)
            {
                spawnedObjects.Add(Instantiate(_prefabToSpawn, hit.pose.position, hit.pose.rotation));
            }
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



    private bool CanInstancePrefab(TorretTypes typeSelected)
    {
        return false;
    }
}
