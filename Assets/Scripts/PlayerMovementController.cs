using ECM.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : BaseCharacterController
{
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private Transform _playerDirection;

    protected override void HandleInput()
    {
        if (_joystickController.InputDirection == Vector2.zero)
        {
            base.HandleInput();
        }
        else
        {
            //moveDirection = new Vector3
            //{
            //    x = _playerDirection.forward.x * _joystickController.InputDirection.x,
            //    y = 0.0f,
            //    z = _playerDirection.forward.z * _joystickController.InputDirection.y,
            //};

            moveDirection = new Vector3
            {
                x = _joystickController.InputDirection.x,
                y = 0.0f,
                z = _joystickController.InputDirection.y
            };
        }
    }
}
