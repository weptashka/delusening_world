using System;
using UnityEngine;
using UnityEngine.UI;

public class MapPopup : Popup
{
    public override WindowType Type => WindowType.Map;

    [SerializeField] private GameObject _levelCellsParent;

    [SerializeField] private Color _colorForCurrentLevelCell;
    [SerializeField] private Color _colorDefaultLevelCell;

    private LevelCell[] _levelCells;

    private int sceneId = 1;

    private void OnEnable()
    {
        LevelLoader.Instance.SceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(string sceneName, string connectedPointId)
    {
        _levelCells = _levelCellsParent.GetComponentsInChildren<LevelCell>(true);

        for (int i = 0; i < _levelCells.Length; i++)
        {
            if (_levelCells[i].CellId == sceneId)
            {
                _levelCells[i].GetComponent<Image>().color = _colorDefaultLevelCell;
            }
        }

        Int32.TryParse(sceneName.Substring(6), out sceneId);
        Debug.Log($"Scene Id {sceneId}");

        for (int i = 0; i < _levelCells.Length; i++)
        {
            if (_levelCells[i].CellId == sceneId)
            {
                _levelCells[i].GetComponent<Image>().color = _colorForCurrentLevelCell;
            }
        }
    }



}