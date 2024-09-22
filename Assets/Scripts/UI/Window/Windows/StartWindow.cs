using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

public class StartWindow : Window
{
    public override WindowType Type => WindowType.Start;

    private LevelLoader _levelLoader;
    [SerializeField] private LevelSettings _levelSettings;


    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private UISystem _uiSystem;

    public void Start()
    {
        _levelLoader = LevelLoader.Instance;
        _uiSystem = UISystem.Instance;

        _startButton.onClick.AddListener(OnStartButtonClick);
        _quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void OnStartButtonClick()
    {
        _uiSystem.Close(WindowType.Start);
        _uiSystem.OpenWindow(WindowType.Game, false);
        _levelLoader.LoadLevel(PlayerStorageData.GetCurrentSceneName(), PlayerStorageData.GetCurrentLoadSpawnPointId()) ;
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
