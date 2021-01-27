using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Rigidbody2D _rb;
    Vector2 _direction;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = new Vector2(-1, -1);
    }

    void FixedUpdate()
    {
        _rb.velocity = _direction * _moveSpeed;
    }
}
