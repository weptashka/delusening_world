using ECM.Controllers;
using UnityEngine;

public class PlayerMovementController : BaseCharacterController
{
    private JoystickController _joystickController;

    public override void Awake()
    {
        base.Awake();

        _joystickController = JoystickController.Instance;
    }

    protected override void HandleInput()
    {
        if (_joystickController.InputDirection == Vector2.zero)
        {
            base.HandleInput();
        }
        else
        {
            moveDirection = new Vector3
            {
                x = _joystickController.InputDirection.x,
                y = 0.0f,
                z = _joystickController.InputDirection.y
            };


            //if (transform.rotation != Camera.main.transform.localRotation)
            //{
            //    moveDirection = transform.localRotation * moveDirection;
                
            //}
            //else
            //{
                //moveDirection = Camera.main.transform.localRotation * moveDirection;
            //}
        }
    }
}
