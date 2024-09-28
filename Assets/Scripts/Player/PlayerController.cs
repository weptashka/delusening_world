using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _playerAnimator;

    private float _lastTime = 0;
    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = new Vector3(0,0,0);
    }

    private void Update()
    {

        if (Mathf.Abs(_playerTransform.position.x - _lastPosition.x) > 0.1f && Mathf.Abs(_playerTransform.position.z - _lastPosition.z) > 0.1f)
        {
            _playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            _playerAnimator.SetBool("isMoving", false);
        }

        if (Time.time - _lastTime > 0.5f)
        {
            _lastTime = Time.time;
            _lastPosition = _playerTransform.position;
        }

    }
}
