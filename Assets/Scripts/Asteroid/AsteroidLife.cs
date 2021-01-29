using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject _smallerAsteroid;
    [SerializeField] int _life;
    [SerializeField] int _scoreValue;
    public int ScoreValue
    {
        get => _scoreValue;
        set => _scoreValue = Mathf.Clamp(value, 0, 10);
    }
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
        {
            GameObject asteroid = Instantiate(_smallerAsteroid, transform.position, transform.rotation);
            asteroid.GetComponent<AsteroidLife>().ScoreValue = ScoreValue;
        }
        else
        {
            Score.ScoreCount += ScoreValue;
        }
        Destroy(gameObject);
    }
}
