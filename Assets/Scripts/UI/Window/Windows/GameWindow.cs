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
    [SerializeField] private Button _attackButton;

    private UISystem _uiSystem;

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
        _attackButton.onClick.AddListener(OnAttackButtonClick);

        _coinCount.text = PlayerStorageData.GetPickableCount(PickableType.Coin).ToString();
        _hpCount.text = PlayerStorageData.GetPickableCount(PickableType.HP).ToString();
    }

    private void OnMenuButtonClick()
    {
        Debug.Log("OnMenuButtonClick");
        _uiSystem.OpenWindow(WindowType.Menu, true);
        _uiSystem.OpenWindow(WindowType.Settings, true);
    }
    
    private void OnAttackButtonClick()
    {
        Debug.Log("ATTACK");
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
