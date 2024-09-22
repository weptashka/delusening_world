using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private BaseWindow[] _windows;
    [SerializeField] private List<BaseWindow> _openedWindows;

    public static UISystem Instance;
    private BaseWindow _currentWindow;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _windows = GetComponentsInChildren<BaseWindow>(true);

        foreach (var window in _windows)
        {
            window.Close();
        }

        OpenWindow(WindowType.Start, false);
    }

    public void OpenWindow(WindowType windowType, bool setAsLastSibling)
    {
        var windowToOpen = _windows.FirstOrDefault(x => x.Type == windowType);

        if (windowToOpen == null)
        {
            return;
        }

        if (setAsLastSibling)
        {
            windowToOpen.transform.SetAsLastSibling();
        }

        if (_openedWindows.Contains(windowToOpen) && windowToOpen.IsPopup)
        {
            return;
        }

        if (_currentWindow != null && !windowToOpen.IsPopup) //если мы оккрываем не попап (окно) и текущее окно!=0
        {
            foreach (var window in _openedWindows)
            {
                window.Close(); //закрываем всеокна в списке открытых
            }

            _currentWindow.Close(); // закрываем и текущее окно
            _openedWindows.Clear();
        }

        windowToOpen.Open();
        _currentWindow = windowToOpen;
        _openedWindows.Add(windowToOpen);
    }

    public void Close(WindowType windowType)
    {
        var windowToClose = _windows.FirstOrDefault(x => x.Type == windowType);

        if (windowToClose == null)
        {
            return;
        }

        if (!_openedWindows.Contains(windowToClose))
        {
            return;
        }

        if (_openedWindows.Count <= 1)
        {
            return;
        }

        var indexOf = _openedWindows.IndexOf(windowToClose);
        _openedWindows[indexOf].Close(); //странно
        _openedWindows.Remove(_openedWindows[indexOf]);
        _currentWindow = _openedWindows[^1];
    }
}