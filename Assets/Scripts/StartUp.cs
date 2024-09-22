using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    [SerializeField] private float _hideTime;
    [SerializeField] private CanvasGroup _splash;

    [SerializeField] private string _uiSceneName;
    [SerializeField] private string _startUpSceneName;
    [SerializeField] private string _firstSceneName;

    [SerializeField] private LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader.Init();

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

        _levelLoader.LoadLevel(_firstSceneName, string.Empty);
    }

    private void LevelLoaderOnSceneLoaded(string s1, string s2)
    {
        DontDestroyOnLoad(_levelLoader);
        StartCoroutine(Unload());
        _levelLoader.SceneLoaded -= LevelLoaderOnSceneLoaded;
    }

    private IEnumerator Unload()
    {
        float time = 0;

        while (time <= _hideTime)
        {
            float progress = time / _hideTime;

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
