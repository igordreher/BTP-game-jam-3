using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<IDamageable>().TakeDamage();
    }
}
