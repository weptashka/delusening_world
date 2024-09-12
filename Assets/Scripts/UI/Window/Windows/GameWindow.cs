using System;
using TMPro;
using UnityEngine;

public class GameWindow : Window
{
    public override WindowType Type => WindowType.Game;

    [SerializeField] private TMP_Text _coinCount;
    [SerializeField] private TMP_Text _hpCount;

    private void OnEnable()
    {
        PlayerStorageData.CoinCountChnged += OnCoinCountChanged; 
        PlayerStorageData.HPCountChanged += OnHPCountChanged; 
    }

    private void OnDisable()
    {
        PlayerStorageData.CoinCountChnged -= OnCoinCountChanged;
        PlayerStorageData.HPCountChanged -= OnHPCountChanged;
    }

    private void OnCoinCountChanged(int count)
    {
        _coinCount.text = count.ToString();
    }
    
    private void OnHPCountChanged(int count)
    {
        _hpCount.text = count.ToString();
    }
}
