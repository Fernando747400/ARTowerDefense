using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private EnemySeeker _enemySeeker;
    [SerializeField] private GameObject _YawPoint;
    [SerializeField] private GameObject _PitchPoint;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private GameObject _BulletSpawner;
    [SerializeField] private Animator _CatapultAnimatior;

    [Header("Follow Target")]
    [SerializeField] private FollowTarget _followYaw;
    [SerializeField] private FollowTarget _followPitch;

    [Header("Settings")]
    [SerializeField] private float _SpeedDamp;
    [SerializeField] private float _SpeedBullet;
    [SerializeField] private bool _isMortar;

    public GameObject Enemy;

    private Vector3 _direction;
    private float cooldown;
    private float currentCool;
    private float enemySearchCool;
    private float currentEnemySearchCool;

    private void Start()
    {
        _followPitch.Target = Enemy;
        _followYaw.Target = Enemy;
        _enemySeeker.SphereCastPosition = this.transform.position;
        _enemySeeker.SphereCastRadius = this.gameObject.GetComponent<SphereCollider>().radius;
        _enemySeeker.SphereCastDistance = this.gameObject.GetComponent<SphereCollider>().radius;
        cooldown = 3f;
        enemySearchCool = 1f;
    }


    private void Update()
    {
        if (Enemy != null)
        {
            _YawPoint.transform.rotation = _followYaw.FinalRotation;
            _PitchPoint.transform.rotation = _followPitch.FinalRotation;
            RotateSpecial(_PitchPoint.transform.rotation.eulerAngles);

            if (currentCool > cooldown)
            {
                currentCool = 0f;
                //Shoot();
                Debug.Log("try to shoot");
                _CatapultAnimatior.Play("Catapulta",0,0f);
                //_CatapultAnimatior.SetBool("ShootAnim", true);
                //_CatapultAnimatior.SetBool("ShootAnim", false);
            }
        }
        else
        {
            if (currentEnemySearchCool > enemySearchCool)
            {
                currentEnemySearchCool = 0f;
                GetMyEnemies();
            }
        }
        currentCool += Time.deltaTime;
        currentEnemySearchCool += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetMyEnemies();
    }

    private void GetMyEnemies()
    {
        _enemySeeker.GetEnemies();
        GameObject closest = _enemySeeker.Closest();
        _followPitch.Target = closest;
        _followYaw.Target = closest;
        Enemy = closest;
    }

    private void RotateSpecial(Vector3 rotation)
    {
        Vector3 temporal;
        temporal.x = rotation.x;
        temporal.y = rotation.y;
        temporal.z = rotation.z;
        _PitchPoint.transform.rotation = Quaternion.Euler(ChangeAngle(temporal));
    }

    public void Shoot()
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

    private Vector3 ChangeAngle(Vector3 rotation)
    {
        float angle = 0f;
        if (_isMortar) angle = (float)CalculateFullAngle();
        else angle = (float)CalculateAngle();

        if (angle > 0) rotation.x = -angle;
        else rotation.x = angle;

        return rotation;
    }

    //TODO https://www.forrestthewoods.com/blog/solving_ballistic_trajectories/
}
