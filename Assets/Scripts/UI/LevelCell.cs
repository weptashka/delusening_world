using UnityEngine;

public class LevelCell : MonoBehaviour
{
    [SerializeField] private int _cellId;

    public int CellId => _cellId;
}
