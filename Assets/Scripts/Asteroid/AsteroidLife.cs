using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject _smallerAsteroid;
    Asteroid _asteroid;
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

    void Awake()
    {
        _asteroid = GetComponent<Asteroid>();
    }

    public void TakeDamage()
    {
        Life--;
    }

    void Die()
    {
        if (_smallerAsteroid != null)
        {
            GameObject asteroid = Instantiate(_smallerAsteroid, transform.position, transform.rotation);
            Asteroid smallerAsteroid = asteroid.GetComponent<Asteroid>();
            smallerAsteroid.ScoreValue = _asteroid.ScoreValue;
            smallerAsteroid.moveSpeed = _asteroid.moveSpeed + 1;
        }
        else
        {
            Score.ScoreCount += _asteroid.ScoreValue;
        }
        Destroy(gameObject);
    }
}
