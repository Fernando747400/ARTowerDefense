using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI_CodeStore : MonoBehaviour
{
    public Text coinsText;

    private CurrencyManager_CodeStore _currencyManager;

    private void Start()
    {
        _currencyManager = GetComponent<CurrencyManager_CodeStore>();
    }

    private void Update()
    {
        coinsText.text = "Coins: " + _currencyManager.CoinsCurrent;
    }
}
