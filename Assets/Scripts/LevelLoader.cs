using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ILevelLoader
{
    public void Init();

    public event Action<string> SceneLoaded;
    public void LoadLevel(string sceneName);
}

public class LevelLoader : MonoBehaviour, ILevelLoader
{
    private readonly string _scenesPathStart = "Assets/Scenes/";
    private readonly string _scenesPathEnd = ".unity";

    private string _currentScene = string.Empty;

    private Coroutine _startCourutine;

    public event Action<string> SceneLoaded;

    public static LevelLoader _instance;
    public static LevelLoader Instance => _instance;

    public void Init()
    {
        _instance = this;
    }

    public Coroutine LoadLevel(string sceneName)
    {
        if (_startCourutine != null)
        {
            StopCoroutine(_startCourutine);
        }

        _startCourutine = StartCoroutine(LoadCor(sceneName));

        return _startCourutine;
    }

    private IEnumerator LoadCor(string sceneName)
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

        SceneLoaded?.Invoke(sceneName);
    }

    void ILevelLoader.LoadLevel(string sceneName)
    {
        throw new NotImplementedException();
    }
}
