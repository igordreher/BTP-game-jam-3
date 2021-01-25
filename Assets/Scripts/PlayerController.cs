using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject _bulletPrefab;
    Rigidbody2D _rb;
    IGun _gun;
    Vector2 _movementInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _gun = new ShotGun(_firePoint, gameObject, _bulletPrefab);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        _gun.Shoot();
    }

    void FixedUpdate()
    {
        _rb.velocity = _movementInput * _moveSpeed;
    }
}
