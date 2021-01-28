using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Transform _player;
    Rigidbody2D _rb;
    float _distanceFromPlayer;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        _distanceFromPlayer = Vector3.Distance(transform.position, _player.position);
        if (_distanceFromPlayer > 16)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        _rb.velocity = transform.up * _moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<IDamageable>().TakeDamage();
    }
}
