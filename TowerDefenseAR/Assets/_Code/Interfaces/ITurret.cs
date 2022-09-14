using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurret 
{
    float Damage
    {
        get;
        set;
    }

    float UpgradeCost
    {
        get;
        set;
    }

    int CurrentLevel
    {
        get;
        set;
    }

    int EnemiesToAttack
    {
        get;
        set;
    }

}
