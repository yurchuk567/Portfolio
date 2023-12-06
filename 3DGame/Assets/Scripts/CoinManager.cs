using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public int _numberOfCoins;
    [SerializeField] TextMeshProUGUI _text;

    private void Start()
    {
        _numberOfCoins = Progress.Instance.Coins;
        _text.text = _numberOfCoins.ToString();
    }

    public void AddOne()
    {
        _numberOfCoins++;
        _text.text = _numberOfCoins.ToString();
    }
    public void SaveToProgress()
    {
        Progress.Instance.Coins = _numberOfCoins;
    }
    public void SpendMoney(int value)
    {
        _numberOfCoins -= value;
        _text.text = _numberOfCoins.ToString();
    }
}
