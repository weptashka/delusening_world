using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    [SerializeField] private float _hideTime;
    [SerializeField] private CanvasGroup _splash;

    [SerializeField] private string _uiSceneName;
    [SerializeField] private string _startUpSceneName;

    [SerializeField] private UISystem _uiSystem;
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private SceneSetupper _sceneSetupper;

    private void Awake()
    {
        _levelLoader.Init();

        _sceneSetupper.Init();

        StartCoroutine(Load());

    }

    private IEnumerator Load()
    {
        var operation = SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);

        while (operation.isDone) 
        {
            yield return null;
        }

        _levelLoader.SceneLoaded += LevelLoaderOnSceneLoaded;
        _levelLoader.LoadLevel(_levelSettings.LevelsQueue.First());
    }

    private void LevelLoaderOnSceneLoaded(string obj)
    {
        StartCoroutine(Unload());
        _levelLoader.SceneLoaded -= LevelLoaderOnSceneLoaded;

    }

    private IEnumerator Unload()
    {
        float time = 0;

        float progress = 0;

        while (time <= _hideTime)
        { 
            _splash.alpha = Mathf.Lerp(1, 0, progress);
            time += Time.deltaTime;

            yield return null;
        }


        var operation = SceneManager.UnloadSceneAsync(_startUpSceneName);

        while (operation.isDone)
        {
            yield return null;
        }
    }
}
