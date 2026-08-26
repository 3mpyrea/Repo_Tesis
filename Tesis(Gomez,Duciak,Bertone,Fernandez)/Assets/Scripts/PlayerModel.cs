using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] InputActionReference _moveAction;
    [SerializeField] float _speed;
    public event Action<Vector2> OnMove;

    IController _controller;

    Rigidbody _rgbd;
    void Start()
    {
        _controller = new PlayerController(this, _moveAction);
    }
    private void Update()
    {
        _controller.UpdateKeys();
    }

    private void FixedUpdate()
    {
        _controller.FixedUpdateKeys();
    }


    public void Move(Vector2 direction)
    {
        var newDirection = transform.forward * direction.y + transform.right * direction.x;

        transform.position += newDirection * (_speed * Time.fixedDeltaTime);

        OnMove?.Invoke(direction);
    }

}
