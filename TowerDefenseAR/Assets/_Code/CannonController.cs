using System.Collections;
using System.Collections.Generic;
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
        LookAtEnemey();
    }

    private void LookAtEnemey()
    {
        Vector3 targetPositionHorizontal = _YawPoint.transform.position - Enemy.transform.position;
        targetPositionHorizontal.y = 0;
        var yawRotation = Quaternion.LookRotation(targetPositionHorizontal);
        transform.rotation = Quaternion.Slerp(_YawPoint.transform.rotation, yawRotation, _SpeedDamp * Time.deltaTime);

        Vector3 targetPositionVertical = _PitchPoint.transform.position - Enemy.transform.position;
        targetPositionVertical.x = 0;
        var pitchRotation = Quaternion.LookRotation(targetPositionVertical);
        transform.rotation = Quaternion.Slerp(_PitchPoint.transform.rotation, pitchRotation, _SpeedDamp * Time.deltaTime);
    }


}
