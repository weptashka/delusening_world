using UnityEngine;
using UnityEngine.UI;

public class MenuPopup : Popup
{
    public override WindowType Type => WindowType.Menu;

    [Header("Buttons")]
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _mapButton;
    [SerializeField] private Button _missionButton;

    private UISystem _uiSystem;

    public void Start()
    {
        _uiSystem = UISystem.Instance;

        _closeButton.onClick.AddListener(OnCloseButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _mapButton.onClick.AddListener(OnMapButtonClick);
        _missionButton.onClick.AddListener(OnMissionButtonClick);
    }

    private void OnCloseButtonClick()
    {
        _uiSystem.Close(WindowType.Menu);
        _uiSystem.Close(WindowType.Settings);
        _uiSystem.Close(WindowType.Map);
        _uiSystem.Close(WindowType.Mission);
    }

    private void OnSettingsButtonClick()
    {
        _uiSystem.Close(WindowType.Map);
        _uiSystem.Close(WindowType.Mission);
        _uiSystem.OpenWindow(WindowType.Settings, true);
    }

    private void OnMapButtonClick()
    {
        _uiSystem.Close(WindowType.Settings);
        _uiSystem.Close(WindowType.Mission);
        _uiSystem.OpenWindow(WindowType.Map, true);
    }

    private void OnMissionButtonClick()
    {
        _uiSystem.Close(WindowType.Settings);
        _uiSystem.Close(WindowType.Map);
        _uiSystem.OpenWindow(WindowType.Mission, true);
    }
}
