using UnityEngine;

public class TransitionArea : MonoBehaviour
{
    [SerializeField] private string _connectedPointId;
    [SerializeField] private string _sceneName;

    private LevelLoader _levelLoader;
    private UISystem _uiSystem;

    private void Awake()
    {
        _levelLoader = LevelLoader.Instance;
        _uiSystem = UISystem.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovementController player))
        {
            _levelLoader.LoadLevel(_sceneName, _connectedPointId);
            _uiSystem.OpenWindow(WindowType.Load, true);
        }
    }
}
