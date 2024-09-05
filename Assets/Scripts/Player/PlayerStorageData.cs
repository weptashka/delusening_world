using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerStorageData : MonoBehaviour
{
    private static readonly string COINS_KEY = "Coins";
    private static readonly string HP_KEY = "HP";

    public static PlayerStorageData _instance;
    public static PlayerStorageData Instance => _instance;

    public void Init()
    {
        _instance = this;
    }

    public void Set(PickableType type, int count)
    {
        switch (type)
        {
            case PickableType.Coin:
                PlayerPrefs.SetInt(COINS_KEY, count + PlayerPrefs.GetInt(COINS_KEY));
                break;
            case PickableType.HP:
                PlayerPrefs.SetInt(HP_KEY, count + PlayerPrefs.GetInt(HP_KEY));
                break;
        }
    }


    public int Get(PickableType type)
    {
        switch (type)
        {
            case PickableType.Coin:
                return PlayerPrefs.GetInt(COINS_KEY);
 
            case PickableType.HP:
                return PlayerPrefs.GetInt(HP_KEY);
            default:
                return 0;
        }
    }

}
