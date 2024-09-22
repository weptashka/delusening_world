using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : Popup
{
    public override WindowType Type => WindowType.Settings;

    [Header("Buttons")]
    [SerializeField] private Button _goToHomeButton;

    private UISystem _uiSystem;

    public void Start()
    {
        _uiSystem = UISystem.Instance;
        _goToHomeButton.onClick.AddListener(OnGoToHomeButtonClick);
    }

    private void OnGoToHomeButtonClick()
    {
        _uiSystem.OpenWindow(WindowType.Start, true);
    }
}