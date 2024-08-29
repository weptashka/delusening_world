using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class SceneSetupper : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    public static SceneSetupper _instance;
    public static SceneSetupper Instance => _instance;

    public void Init()
    {
        _instance = this;
    }

    public void SetupScene(string sceneName, int spawnPointIndex)
    { 
        //находим эту спавн точку на карте, находим её transformPosition

        //Instatiate(_playerPrefab, newVector(//позиция точки спавна));
    }
}
