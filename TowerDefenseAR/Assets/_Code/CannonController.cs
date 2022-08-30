using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _YawPoint;
    [SerializeField] private GameObject _PitchPoint;

    [Header("Settings")]
    [SerializeField] private float _SpeedDamp;

    public GameObject Enemy;

    private void Update()
    {
        LookAt(_YawPoint, Enemy,'y');
        LookAt(_PitchPoint, Enemy, 'a');
    }

    private void LookAt(GameObject looker, GameObject target, char axis)
    {
        Vector3 targetVector = target.transform.position - looker.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetVector);
        Vector3 rotation = lookRotation.eulerAngles;
        switch (axis)
        {
            case 'x':
                rotation.y = 0;
                rotation.z = 0;
                break;

            case 'y':
                rotation.x = 0;
                rotation.z = 0;
                break;

            case 'z':
                rotation.x = 0;
                rotation.y = 0;
                break;

            case 'a':
                break;

            default:
                Debug.Log("Incorrect axis or casing typed");
                return;
                break;
        }
       
        looker.transform.rotation = Quaternion.Euler(rotation);
    }


}
