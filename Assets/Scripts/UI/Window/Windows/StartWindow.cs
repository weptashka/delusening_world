using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StartWindow : Window
{
    public override WindowType Type => WindowType.Start;

    private LevelLoader _levelLoader;
    [SerializeField] private LevelSettings _levelSettings;


    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private void Awake()
    {
        _levelLoader = LevelLoader.Instance;
    }

    public void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        UISystem.Instance.Close(WindowType.Start);
        UISystem.Instance.OpenWindow(WindowType.Game, false);
        _levelLoader.LoadLevel(_levelSettings.LevelsQueue.First(), string.Empty);
    }
}
