using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionArea : MonoBehaviour
{
    public static event Action<int> TransitionAreaTriggered;

    [SerializeField] private int _transitionAreaIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovementController player))
        {
            //SceneManager.LoadScene("Assets/Scenes/Scene_2.unity");

            TransitionAreaTriggered?.Invoke(_transitionAreaIndex);
        }
    }
}
