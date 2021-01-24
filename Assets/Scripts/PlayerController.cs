using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Gun _gun;
    [SerializeField] Transform _firePoint;
    Rigidbody2D _rb;
    Vector2 _movementInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _gun.Initialize(gameObject);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        _gun.Shoot(_firePoint);
    }

    void FixedUpdate()
    {
        _rb.velocity = _movementInput * _moveSpeed;
    }
}
