using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using _Code.XR;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class RaycastSpawner_CodeXR : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Text textNumInstances;

    private List<GameObject> centerList;
    private List<GameObject> turretList;
    public ARRaycastManager raycastManager;
    List<ARRaycastHit> rayHits;
    private BoundedPlane _boundedPlane;

  
    private TurretTypes currentType;
    
    private void Start()
    {
        rayHits = new List<ARRaycastHit>();
        centerList = new List<GameObject>();
        turretList = new List<GameObject>();
    }

    private void OnEnable()
    {
        SpawnerUI_CodeXR spawnerUICodeXR = GetComponent<SpawnerUI_CodeXR>();
        spawnerUICodeXR.OnChangePrefab += HandleAssetPrefab;
        spawnerUICodeXR.OnSelectType += UpdateCurrentType;
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
               InstancePrefab(hit);
            }
        }
    }

    private bool GetTouch(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    

    private bool CanInstancePrefab()
    { 
        int maxPrefabs = 4;
        int centerPrefab = 1;
        
        switch (currentType)
        {
            case TurretTypes.Center:
                if (centerList.Count >= centerPrefab) return false;
                break;
            case TurretTypes.Laser or TurretTypes.Tower:
                if (turretList.Count >= maxPrefabs) return false;
                break;
            
        }
        return true;
    }

    public void UpdateCurrentType(int type)
    {
        currentType = (TurretTypes)type;
    }

    public void InstancePrefab(ARRaycastHit hit)
    {
        if (CanInstancePrefab())
        {
            switch (currentType)
            {
                case TurretTypes.Center:
                    centerList.Add(Instantiate(_prefabToSpawn, hit.pose.position, hit.pose.rotation));
                    break;
                case TurretTypes.Laser or TurretTypes.Tower:
                    turretList.Add(Instantiate(_prefabToSpawn, hit.pose.position, hit.pose.rotation));
                    break;
            }

        }

    }
}
