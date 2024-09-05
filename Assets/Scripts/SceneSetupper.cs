using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class SceneSetupper : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private SpawnPont[] _spawnPoints;


    private LevelLoader _levelLoader;

    private void Awake()
    {
        var currentLoadSpawnPointId = GlobalLevelData.CurrentLoadSpawnPointId;

        if (currentLoadSpawnPointId.Equals(string.Empty))
        {
            return;
        }

        var firstOrDefault = _spawnPoints.FirstOrDefault(x=>x.Id.Equals(currentLoadSpawnPointId));
        _levelLoader = LevelLoader.Instance;
        LevelLoader.Instance.SceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(string sceneName, string connectedPointId)
    {
        int connectedPointIdInt = 0;
        Int32.TryParse(connectedPointId, out connectedPointIdInt);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (connectedPointId.Equals(_spawnPoints[i].Id))
            {
                Int32.TryParse(connectedPointId, out connectedPointIdInt);
                SetupScene(connectedPointIdInt);
            }
            else 
            {
                Debug.Log($"There is No Spawn Point With Such Id {connectedPointId} On This Scene");

            }
        }
    }

    public void SetupScene(int spawnPointIndex)
    {
        Instantiate(_playerPrefab, _spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
    }
}
