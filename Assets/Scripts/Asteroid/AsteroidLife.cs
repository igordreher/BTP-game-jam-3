using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject _smallerAsteroid;
    [SerializeField] int _life;
    int Life
    {
        get => _life;
        set
        {
            _life = Mathf.Clamp(value, 0, 10);
            if (_life == 0)
                Die();
        }
    }

    public void TakeDamage()
    {
        Life--;
    }

    void Die()
    {
        if (_smallerAsteroid != null)
            Instantiate(_smallerAsteroid, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
