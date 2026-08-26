using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : IController
{
    PlayerModel _model;

    InputActionReference _moveAction;

    public PlayerController(PlayerModel model, InputActionReference moveInput)
    {
        _model = model;

        _moveAction = moveInput;
    }

    public void FixedUpdateKeys()
    {
        var direction = _moveAction.action.ReadValue<Vector2>();

        _model.Move(direction);
    }

    public void UpdateKeys()
    {
    }
}
