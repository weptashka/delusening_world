using System.Linq;
using UnityEngine;


public class SceneSetupper : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private SpawnPont[] _spawnPoints;

    private void Awake()
    {
        var currentLoadSpawnPointId = PlayerStorageData.GetCurrentLoadSpawnPointId();

        if (currentLoadSpawnPointId.Equals(string.Empty))
        {
            return;
        }

        var firstOrDefault = _spawnPoints.FirstOrDefault(x=>x.Id.Equals(currentLoadSpawnPointId));
        LevelLoader.Instance.SceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        LevelLoader.Instance.SceneLoaded -= OnSceneLoaded;

    }

    private void OnSceneLoaded(string sceneName, string connectedPointId)
    {

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (connectedPointId.Equals(_spawnPoints[i].Id))
            {
                SetupScene(i);
                Debug.Log($"connectedPointIndex : {i}, id : {_spawnPoints[i].Id}");
                return;
            }
        }
    }

    public void SetupScene(int spawnPointIndex)
    {
        //Debug.Log($"_spawnPoints[spawnPointIndex].transform.positionBEGINNING : {_spawnPoints[spawnPointIndex].transform.position}");
        //Debug.Log($"_playerPrefab.transform.positionBEGINNING : {_playerPrefab.transform.position}");
        _playerPrefab.transform.position = _spawnPoints[spawnPointIndex].transform.position;
    }
}
