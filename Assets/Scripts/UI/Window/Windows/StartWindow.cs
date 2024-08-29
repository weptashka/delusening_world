using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : Window
{
    public override WindowType Type => WindowType.Start;

    [Header("Buttons")]
    [SerializeField] private Button _startButton;

    public void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        UISystem.Instance.OpenWindow(WindowType.Game, false);
    }
}
