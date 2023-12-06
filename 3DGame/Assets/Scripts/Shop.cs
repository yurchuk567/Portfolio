using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] CoinManager _coinManager;
    PlayerModifier _playerModifier;

    private void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        EnoughMoney();
        Progress.Instance.Width += 50;
        _playerModifier.SetWidth(Progress.Instance.Width);
    }

    public void BuyHeight()
    {
        EnoughMoney();
        Progress.Instance.Height += 50;
        _playerModifier.SetHeight(Progress.Instance.Height);
    }
    private void EnoughMoney()
    {
        if (_coinManager._numberOfCoins >= 20)
        {
            _coinManager.SpendMoney(20);
            Progress.Instance.Coins = _coinManager._numberOfCoins;

        }
    }
}
