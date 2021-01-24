using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _fireRate;
    [SerializeField] int _clipSize;
    float _nextFireTime;
    GameObject _holder;

    public void Initialize(GameObject holder)
    {
        _holder = holder;
        _nextFireTime = 0;
    }

    public void Shoot(Transform firePoint)
    {
        if (Time.time < _nextFireTime)
            return;
        _nextFireTime = Time.time + 1 / _fireRate;
        GameObject bullet = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetUp(_holder);
    }

}