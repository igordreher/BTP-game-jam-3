using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D _rb;
    Vector2 movementInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
    }

    void FixedUpdate()
    {
        _rb.velocity = movementInput * moveSpeed;
    }
}
