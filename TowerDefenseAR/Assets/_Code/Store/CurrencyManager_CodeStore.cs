using System;
using UnityEditor;
using UnityEngine;

public class CurrencyManager_CodeStore : MonoBehaviour
{
    public static CurrencyManager_CodeStore Instance;
    
    [SerializeField] private int _coinsCurrent;
    public int turretsCost = 2;
    public int CoinsCurrent { get => _coinsCurrent; }


    private void Start()
    {
        Instance = this;
    }

    public void AddCoins(int coinsToAdd)
    {
        _coinsCurrent += coinsToAdd;
    }

    public bool CanRemoveCoins(int coinsToRemove)
    {
        if (coinsToRemove <= _coinsCurrent)
        {
            _coinsCurrent -= coinsToRemove;
            return true;
        } 
        
        _coinsCurrent = 0;

        return false;
    }

    
    // #region Editor

    // public void BuyTurret()
    // {
        // if (CanRemoveCoins(2))
        // {
            // print("Se compra torreta");
        // }
        
        // print(_coinsCurrent);
    // }

    // #endregion
}



// [CustomEditor(typeof(CurrencyManager_CodeStore))]
// public class CurrencyManagerEditor : Editor
// {
    // public override void OnInspectorGUI()
    // {
        // DrawDefaultInspector();
        // CurrencyManager_CodeStore currency = target as CurrencyManager_CodeStore;

        // if (GUILayout.Button("Buy Turret"))
        // {
            // currency.BuyTurret();
        // }
    // }
// }