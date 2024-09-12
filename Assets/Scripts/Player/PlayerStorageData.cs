using System;
using UnityEngine;

public class PlayerStorageData
{
    public static event Action<int> CoinCountChnged;
    public static event Action<int> HPCountChanged;

    private static readonly string COINS_KEY = "Coins";
    private static readonly string HP_KEY = "HP";

    public static void SetPickableCount(PickableType type, int count)
    {
        switch (type)
        {
            case PickableType.Coin:
                count += PlayerPrefs.GetInt(COINS_KEY);
                PlayerPrefs.SetInt(COINS_KEY, count);
                CoinCountChnged?.Invoke(PlayerPrefs.GetInt(COINS_KEY));
                break;
            case PickableType.HP:
                count += PlayerPrefs.GetInt(HP_KEY);
                PlayerPrefs.SetInt(HP_KEY, count);
                HPCountChanged?.Invoke(PlayerPrefs.GetInt(HP_KEY));
                break;
        }
    }

    public static int GetPickableCount(PickableType type)
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
