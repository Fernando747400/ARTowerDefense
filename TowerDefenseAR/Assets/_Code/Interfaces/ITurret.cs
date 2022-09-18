using System.Collections;
using System.Collections.Generic;
using _Code.XR;
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

    public TorretTypes myType
    {
        get;
    }
}
