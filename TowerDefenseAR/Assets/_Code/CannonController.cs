using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _YawPoint;
    [SerializeField] private GameObject _PitchPoint;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private GameObject _BulletSpawner;

    [Header("Follow Target")]
    [SerializeField] private FollowTarget _followYaw;
    [SerializeField] private FollowTarget _followPitch;

    [Header("Settings")]
    [SerializeField] private float _SpeedDamp;
    [SerializeField] private float _SpeedBullet;
    [SerializeField] private bool _isMortar;

    private Vector3 _direction;

    public GameObject Enemy;

    private void Start()
    {
        _followPitch.Target = Enemy;
        _followYaw.Target = Enemy;
    }


    private void Update()
    {
        _YawPoint.transform.rotation = _followYaw.FinalRotation;
        _PitchPoint.transform.rotation = _followPitch.FinalRotation;
        //LookAt(_YawPoint, Enemy,'y');
        //LookAt(_PitchPoint, Enemy, 'a');
        if (Input.GetKeyDown(KeyCode.O)) Shoot();
    }

    //private void LookAt(GameObject looker, GameObject target, char axis)
    //{
    //    Vector3 targetVector = target.transform.position - looker.transform.position;
    //    Quaternion lookRotation = Quaternion.LookRotation(targetVector);
    //    Vector3 rotation = lookRotation.eulerAngles;
    //    switch (axis)
    //    {
    //        case 'x':
    //            rotation.y = 0;
    //            rotation.z = 0;
    //            break;

    //        case 'y':
    //            rotation.x = 0;
    //            rotation.z = 0;
    //            break;

    //        case 'z':
    //            rotation.x = 0;
    //            rotation.y = 0;
    //            break;

    //        case 'a':
    //            float angle = 0f;
    //            if (_isMortar) angle = (float)CalculateFullAngle();
    //            else angle = (float)CalculateAngle();
    //            if (angle > 0) rotation.x = -angle;
    //            else rotation.x = angle;
    //            break;

    //        default:
    //            Debug.Log("Incorrect axis or casing typed");
    //            rotation = Vector3.zero;
    //            break;
    //    }
    //    looker.transform.rotation = Quaternion.Euler(rotation);
    //}

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

    private double CalculateAngle()
    {
        double range = Vector3.Distance(Enemy.transform.position, _PitchPoint.transform.position);
        double angle = 0.5f * (Math.Asin((9.8 * range) / Math.Pow(_SpeedBullet, 2)));
        angle = angle * (180 / Math.PI);
        //Debug.Log("Angle " + angle);
        return angle;
    }

    private double CalculateFullAngle()
    {
        double range = Vector3.Distance(Enemy.transform.position, this.transform.position);
        double height = _PitchPoint.transform.position.y - Enemy.transform.position.y;
        double fAngle = Math.Atan(range/height);
        fAngle = fAngle * (180 / Math.PI);
        double twoa = ((9.8 * Math.Pow(range, 2)) / Math.Pow(_SpeedBullet,2)) - height;
        double sqrHR = Math.Sqrt(Math.Pow(height,2) + Math.Pow(range,2));
        double cosM = twoa / sqrHR;
        double tAngle = Math.Acos(cosM);
        tAngle = tAngle * (180 / Math.PI);
        double angle = (tAngle + fAngle) / 2;
        //Debug.Log("Full angle " + angle);
        return angle;
    }

    private double CalculateFlightTime()
    {
        double angle = CalculateAngle();
        double fTime = 2 * _SpeedBullet * Math.Sin(angle);
        fTime /= 9.8;
        Debug.Log("Flight time " +fTime);
        return fTime;
    }

    //TODO https://www.forrestthewoods.com/blog/solving_ballistic_trajectories/
}
