using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    //public void LoadLevel(string sceneName)
    //{
    //    if (_loadLevelCor != null)
    //    {
    //        StopCoroutine(_loadLevelCor);
    //    }

    //    _loadLevelCor = StartCoroutine(LoadCor(sceneName, string.Empty));
    //}

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
            var unloadSceneAsync = SceneManager.UnloadSceneAsync(sceneName);

            while (!unloadSceneAsync.isDone)
            {
                yield return null;
            }
        }

        var loadSceneAsync = SceneManager.LoadSceneAsync(_scenesPathStart + sceneName + _scenesPathEnd, LoadSceneMode.Additive);

        while (!loadSceneAsync.isDone) 
        {
            yield return null;
        }

        SceneLoaded?.Invoke(sceneName, connectedPointId);
    }
}
