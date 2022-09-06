using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _YawPoint;
    [SerializeField] private GameObject _PitchPoint;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private GameObject _BulletSpawner;

    [Header("Settings")]
    [SerializeField] private float _SpeedDamp;
    [SerializeField] private float _SpeedBullet;

    private Vector3 _direction;

    public GameObject Enemy;

    

    private void Update()
    {
        LookAt(_YawPoint, Enemy,'y');
        LookAt(_PitchPoint, Enemy, 'a');

        if (Input.GetKeyDown(KeyCode.O)) Shoot();
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
                rotation = Vector3.zero;
                break;
        }
       
        looker.transform.rotation = Quaternion.Euler(rotation);
    }

    private void Shoot()
    {
        GameObject bullet;
        _direction = _BulletSpawner.transform.position - _PitchPoint.transform.position;
        _direction.Normalize();
        _direction = _direction * _SpeedBullet;

        bullet = Instantiate(_BulletPrefab, _BulletSpawner.transform.position, Quaternion.identity, _BulletSpawner.transform);
        bullet.GetComponent<Rigidbody>().AddForce(_direction, ForceMode.Impulse);
        bullet.transform.parent = null;
    }

    //TODO https://www.forrestthewoods.com/blog/solving_ballistic_trajectories/
}
