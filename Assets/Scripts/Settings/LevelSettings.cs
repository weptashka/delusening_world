using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "Settings/LevelSettings", fileName = "LevelSettings", order = 0)]
public class LevelSettings : ScriptableObject
    {
        [SerializeField] private string[] _levelsQueue;

        public string[] LevelsQueue => _levelsQueue;
    }

