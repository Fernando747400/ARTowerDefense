using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int _coinsCurrent;

    public int CoinsCurrent { get => _coinsCurrent; }

    public void AddCoins(int coinsToAdd)
    {
        _coinsCurrent += coinsToAdd;
    }

    public void RemoveCoins(int coinsToRemove)
    {
        if (coinsToRemove <= _coinsCurrent)
        {
            _coinsCurrent -= coinsToRemove;
        }
        else _coinsCurrent = 0; 
    }
}
