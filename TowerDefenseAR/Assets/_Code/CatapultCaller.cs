using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultCaller : MonoBehaviour
{
    public CannonController cannonController;

    public void CallShoot()
    {
        cannonController.Shoot();
    }
}
