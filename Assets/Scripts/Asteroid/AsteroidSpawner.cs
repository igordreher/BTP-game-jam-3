using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] float _spawnTime;
    [SerializeField] float _spawnSize;
    [SerializeField] Axis _axis;
    [SerializeField] GameObject _asteroidPrefabLarge;
    [SerializeField] GameObject _asteroidPrefab;
    [SerializeField] GameObject _asteroidPrefabSmall;
    GameObject[] _asteroids;

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0, _spawnTime);
        _asteroids = new GameObject[3];
        _asteroids.SetValue(_asteroidPrefab, 0);
        _asteroids.SetValue(_asteroidPrefabLarge, 1);
        _asteroids.SetValue(_asteroidPrefabSmall, 2);
    }

    void SpawnAsteroid()
    {
        float angle = transform.rotation.eulerAngles.z;
        float randomAngle = Random.Range(angle - 25f, angle + 25f);

        int randomAsteroid = Random.Range(0, 2);
        Instantiate(_asteroids[randomAsteroid], GetSpawnPoint(), Quaternion.Euler(0, 0, randomAngle));
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