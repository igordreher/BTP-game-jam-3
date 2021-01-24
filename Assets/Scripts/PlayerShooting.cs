using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _playerTransform;
    Vector2 _mousePosition;
    Vector2 _projectedMousePosition;
    Vector2 _lookingDirection;
    float _lookingAngle;
    PlayerInput _playerInput;

    void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        Shoot();
    }

    void Update()
    {
        SetRotation();
    }

    void SetRotation()
    {
        _mousePosition = _playerInput.actions["Aim"].ReadValue<Vector2>();
        _projectedMousePosition = _camera.ScreenToWorldPoint(_mousePosition);
        _lookingDirection = _projectedMousePosition - (Vector2)_playerTransform.position;
        _lookingAngle = Mathf.Atan2(_lookingDirection.y, _lookingDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _lookingAngle);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Bullet>().SetUp(_playerTransform.gameObject);
    }
}