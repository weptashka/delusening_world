using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindow : Window
{
    public override WindowType Type => WindowType.Game;

    [SerializeField] private TMPro.TextMeshPro _coinCount;
    [SerializeField] private TMPro.TextMeshPro _hpCount;

    private PlayerStorageData _playerStarageData;

    private void Update()
    {
        _coinCount.text = _playerStarageData.Get(PickableType.Coin).ToString();
        _hpCount.text = _playerStarageData.Get(PickableType.HP).ToString();
    }
}
