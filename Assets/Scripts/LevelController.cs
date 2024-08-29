using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;

    private object[] sceneMapping;


    private void OnEnable()
    {
        TransitionArea.TransitionAreaTriggered += OnTransitionAreaTriggered;
    }

    private void OnTransitionAreaTriggered(int spawnPointIndex)
    {
        //маппингом остать - current scene - Пришедший transitionAreaIndex - достать next scene name

        LevelLoader.Instance.LoadLevel(sceneName);

        SceneSetupper.Instance.SetupScene(sceneName, spawnPointIndex);
    }


}

