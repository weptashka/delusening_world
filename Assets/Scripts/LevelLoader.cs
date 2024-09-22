using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    private readonly string _scenesPathStart = "Assets/Scenes/";
    private readonly string _scenesPathEnd = ".unity";

    public event Action<string, string> SceneLoaded;

    private string _currentScene = string.Empty;

    private Coroutine _loadLevelCor;

    public static LevelLoader _instance;
    public static LevelLoader Instance => _instance;

    public void Init()
    {
        _instance = this;
    }


    public void LoadLevel(string sceneName, string connectedPointId)
    {
        if (_loadLevelCor != null)
        {
            StopCoroutine(_loadLevelCor);
        }

        GlobalLevelData.CurrentLoadSpawnPointId = connectedPointId;

        _loadLevelCor = StartCoroutine(LoadCor(sceneName, connectedPointId));
    }


    private IEnumerator LoadCor(string sceneName, string connectedPointId)
    {
        if (_currentScene != string.Empty)
        {
            var unloadSceneAsync = SceneManager.UnloadSceneAsync(_currentScene);

            while (!unloadSceneAsync.isDone)
            {
                yield return null;
            }
        }

        var scenePathStart = _scenesPathStart + sceneName + _scenesPathEnd;

        var loadSceneAsync = SceneManager.LoadSceneAsync(scenePathStart, LoadSceneMode.Additive);

        while (!loadSceneAsync.isDone) 
        {
            yield return null;
        }

        _currentScene = scenePathStart;

        SceneLoaded?.Invoke(sceneName, connectedPointId);
    }
}
