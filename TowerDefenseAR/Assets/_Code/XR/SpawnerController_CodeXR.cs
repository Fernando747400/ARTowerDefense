using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using _Code.XR;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class SpawnerController_CodeXR : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject prefabToSpawn;
    public ARRaycastManager raycastManager;
    
    private List<GameObject> _centerList;
    private List<GameObject> _turretList;
    private List<ARRaycastHit> _rayHits;
    private BoundedPlane _boundedPlane;
    private TurretTypes _currentType;
    
    private void Start()
    {
        _rayHits = new List<ARRaycastHit>();
        _centerList = new List<GameObject>();
        _turretList = new List<GameObject>();
    }

    private void OnEnable()
    {
        SpawnerUI_CodeXR spawnerUICodeXR = GetComponent<SpawnerUI_CodeXR>();
        spawnerUICodeXR.OnChangePrefab += HandleAssetPrefab;
        spawnerUICodeXR.OnSelectType += UpdateCurrentType;
        spawnerUICodeXR.OnResetPrefabs += ResetInstancesPrefabs;
    }

    private void HandleAssetPrefab(GameObject prefab)
    {
        prefabToSpawn = prefab;
        
    }

    private void Update()
    {
        if (GetTouch(out Vector2 touchPosition))
        {
            if (raycastManager != null)
            {
                if(raycastManager.Raycast(touchPosition, _rayHits, TrackableType.PlaneWithinPolygon))
                {
                    var hit = _rayHits[0];
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
        
        switch (_currentType)
        {
            case TurretTypes.Center:
                if (_centerList.Count >= centerPrefab) return false;
                break;
            case TurretTypes.Laser or TurretTypes.Tower:
                if (_turretList.Count >= maxPrefabs) return false;
                break;
            
        }
        return true;
    }

    public void UpdateCurrentType(int type)
    {
        _currentType = (TurretTypes)type;
    }

    public void InstancePrefab(ARRaycastHit hit)
    {
        int costTurret = CurrencyManager_CodeStore.Instance.turretsCost;
        if (CanInstancePrefab())
        {
            switch (_currentType)
            {
                case TurretTypes.Center:
                    _centerList.Add(Instantiate(prefabToSpawn, hit.pose.position, hit.pose.rotation));
                    break;
                case TurretTypes.Laser or TurretTypes.Tower:
                    if (CurrencyManager_CodeStore.Instance.CanRemoveCoins(costTurret))
                    {
                        _turretList.Add(Instantiate(prefabToSpawn, hit.pose.position, hit.pose.rotation));
                    }
                    break;
            }
        }
    }

    private void ResetInstancesPrefabs()
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("TrackedImage");

        for (int i = 0; i < prefabs.Length; i++)
        {
            Destroy(prefabs[i]);
        }
        _centerList = new List<GameObject>();
        _turretList = new List<GameObject>();
    }
    
    
}
