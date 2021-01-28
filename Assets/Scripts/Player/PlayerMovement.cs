using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Rigidbody2D _rb;
    Vector2 _movementInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _movementInput = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        _rb.velocity = _movementInput * _moveSpeed;
    }
}
