using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    public float live;
    private Vector3 initialPos;
    private float initialLife;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        initialPos = this.transform.position;
        initialLife = live;
    }

    void Update()
    {
        if(live <= 0)
        {
            CurrencyManager_CodeStore.Instance.AddCoins(2);
            RestartPool();
        }
    }

    public void RestartPool()
    {
        this.transform.position = initialPos;
        live = initialLife;

    }
}
