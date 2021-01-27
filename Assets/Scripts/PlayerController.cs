using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Transform _firePoint;
    [SerializeField] GameObject _bulletPrefab;
    Rigidbody2D _rb;
    Gun[] _guns;
    Gun _currentGun;
    int _selectedGun;
    bool _isShooting;
    Vector2 _movementInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _firePoint = GetComponentInChildren<Transform>();
    }

    void Start()
    {
        _guns = new Gun[2];
        _guns[0] = new StandardGun(_firePoint, gameObject, _bulletPrefab);
        _guns[1] = new ShotGun(_firePoint, gameObject, _bulletPrefab);
        _currentGun = _guns[0];
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        _isShooting = context.performed;
        if (!context.started)
            return;
        _currentGun.Shoot();
    }

    public void OnSwitchGun(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        if (_selectedGun == 0)
            _selectedGun++;
        else
            _selectedGun--;

        _currentGun = _guns[_selectedGun];
    }

    void Update()
    {
        if (_isShooting)
        {
            _currentGun.Shoot();
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = _movementInput * _moveSpeed;
    }
}
