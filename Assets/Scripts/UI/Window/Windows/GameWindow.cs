using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
    public override WindowType Type => WindowType.Game;

    [SerializeField] private TMP_Text _coinCount;
    [SerializeField] private TMP_Text _hpCount;

    [Header("Buttons")]
    [SerializeField] private Button _menuButton;

    private UISystem _uiSystem;

    private void OnGoToHomeButtonClick()
    {
        _uiSystem.Close(WindowType.Menu);
        _uiSystem.Close(WindowType.Settings);
        _uiSystem.Close(WindowType.Game);
        _uiSystem.OpenWindow(WindowType.Start, false);
    }

    private void OnEnable()
    {
        PlayerStorageData.CoinCountChnged += OnCoinCountChanged; 
        PlayerStorageData.HPCountChanged += OnHPCountChanged; 
    }

    private void OnDisable()
    {
        PlayerStorageData.CoinCountChnged -= OnCoinCountChanged;
        PlayerStorageData.HPCountChanged -= OnHPCountChanged;
    }

    private void Start()
    {
        _uiSystem = UISystem.Instance;

        _menuButton.onClick.AddListener(OnMenuButtonClick);

        _coinCount.text = PlayerStorageData.GetPickableCount(PickableType.Coin).ToString();
        _hpCount.text = PlayerStorageData.GetPickableCount(PickableType.HP).ToString();
    }

    private void OnMenuButtonClick()
    {
        _uiSystem.OpenWindow(WindowType.Menu, true);
    }

    private void OnCoinCountChanged(int count)
    {
        _coinCount.text = count.ToString();
    }
    
    private void OnHPCountChanged(int count)
    {
        _hpCount.text = count.ToString();
    }
}
