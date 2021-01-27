using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimDirection : MonoBehaviour
{
    [SerializeField] Camera _camera;
    Vector2 _mousePosition;
    Vector2 _projectedMousePosition;
    Vector2 _lookingDirection;
    PlayerInput _playerInput;
    float _lookingAngle;

    void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    void Update()
    {
        SetRotation();
    }

    void SetRotation()
    {
        _mousePosition = _playerInput.actions["Aim"].ReadValue<Vector2>();
        _projectedMousePosition = _camera.ScreenToWorldPoint(_mousePosition);
        _lookingDirection = _projectedMousePosition - (Vector2)transform.position;
        _lookingAngle = Mathf.Atan2(_lookingDirection.y, _lookingDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, _lookingAngle);
    }
}
