using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] float _spawnSize;
    [SerializeField] Axis _axis;
    [SerializeField] GameObject _asteroidPrefabLarge;
    [SerializeField] GameObject _asteroidPrefab;
    [SerializeField] GameObject _asteroidPrefabSmall;
    [SerializeField] float _spawnRaiseTime;
    [SerializeField] float _spawnRaiseAmount;
    GameObject[] _asteroids;
    float _nextSpawnRaiseTime;
    float _spawnTime;
    float SpawnTime
    {
        get => _spawnTime;
        set => _spawnTime = Mathf.Clamp(value, 0, 5);
    }

    void Start()
    {
        SpawnTime = 2;
        _nextSpawnRaiseTime = _spawnRaiseTime;

        InitializeAsteroids();

        StartCoroutine(SpawnAsteroid(1));
    }

    void InitializeAsteroids()
    {
        _asteroids = new GameObject[3];
        _asteroids.SetValue(_asteroidPrefab, 0);
        _asteroids.SetValue(_asteroidPrefabLarge, 1);
        _asteroids.SetValue(_asteroidPrefabSmall, 2);
    }

    IEnumerator SpawnAsteroid(float time)
    {
        yield return new WaitForSeconds(time);

        float angle = transform.rotation.eulerAngles.z;
        float randomAngle = Random.Range(angle - 25f, angle + 25f);

        int randomAsteroid = Random.Range(0, 3);
        Instantiate(_asteroids[randomAsteroid], GetSpawnPoint(), Quaternion.Euler(0, 0, randomAngle));

        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(SpawnAsteroid(0));
    }

    Vector3 GetSpawnPoint()
    {
        Vector3 spawnPoint;
        if (_axis == 0)
        {
            var x1 = transform.position.x - _spawnSize / 2;
            var x2 = transform.position.x + _spawnSize / 2;
            spawnPoint = new Vector3(Random.Range(x1, x2), transform.position.y, 0);
        }
        else
        {
            var y1 = transform.position.y - _spawnSize / 2;
            var y2 = transform.position.y + _spawnSize / 2;
            spawnPoint = new Vector3(transform.position.x, Random.Range(y1, y2), 0);
        }
        return spawnPoint;
    }

    void Update()
    {
        if (Time.time < _nextSpawnRaiseTime)
            return;
        _nextSpawnRaiseTime = Time.time + _spawnRaiseTime;
        SpawnTime -= _spawnRaiseAmount;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_axis == 0)
            Gizmos.DrawWireCube(transform.position, new Vector3(_spawnSize, 1, 0));
        else
            Gizmos.DrawWireCube(transform.position, new Vector3(1, _spawnSize, 0));
    }
}

public enum Axis
{
    Horizontal,
    Vertical
}