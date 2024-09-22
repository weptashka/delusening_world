using System;
using UnityEngine;

public class PlayerStorageData
{
    public static event Action<int> CoinCountChnged;
    public static event Action<int> HPCountChanged;

    private static readonly string COINS_KEY = "Coins";
    private static readonly string HP_KEY = "HP";
    
    private static readonly string CURRENT_LOAD_SPAWN_POINT_ID = "currentLoadSpawnPointId";
    private static readonly string CURRENT_SCENE_NAME = "Scene_1";

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

    public static void SetCurrentLoadSpawnPointId(string currentLoadSpawnPointId)
    {
        PlayerPrefs.SetString(CURRENT_LOAD_SPAWN_POINT_ID, currentLoadSpawnPointId);
    }

    public static string GetCurrentLoadSpawnPointId()
    {
        return PlayerPrefs.GetString(CURRENT_LOAD_SPAWN_POINT_ID);
    }


    public static void SetCurrentSceneName(string currentSceneName)
    {
        PlayerPrefs.SetString(CURRENT_SCENE_NAME, currentSceneName);
    }

    public static string GetCurrentSceneName()
    {
        return PlayerPrefs.GetString(CURRENT_SCENE_NAME);
    }
}
