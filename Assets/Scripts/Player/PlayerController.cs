using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        GetInput();
        if (_isShooting)
        {
            _currentGun.Shoot();
        }
    }

    void GetInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _movementInput = new Vector2(horizontal, vertical);

        _isShooting = Input.GetMouseButton(0);

        if (Input.GetMouseButtonDown(1))
            SwitchGun();
    }

    void SwitchGun()
    {
        if (_selectedGun == 0)
            _selectedGun++;
        else
            _selectedGun--;

        _currentGun = _guns[_selectedGun];
    }

    void FixedUpdate()
    {
        _rb.velocity = _movementInput * _moveSpeed;
    }
}
