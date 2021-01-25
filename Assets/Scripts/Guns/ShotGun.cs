using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : IGun
{
    public float FireRate = 1;
    float _nextFireTime;
    GameObject _bulletPrefab;
    Transform _firePoint;
    GameObject _holder;

    public ShotGun(Transform firePoint, GameObject holder, GameObject bulletPrefab)
    {
        _firePoint = firePoint;
        _holder = holder;
        _bulletPrefab = bulletPrefab;
    }

    public void Shoot()
    {
        if (Time.time < _nextFireTime)
            return;
        _nextFireTime = Time.time + 1 / FireRate;

        ShootThreeBullets();
    }

    void ShootThreeBullets()
    {
        for (int i = -1; i < 2; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, _firePoint.rotation.y + i * 35f);
            GameObject bullet = MonoBehaviour.Instantiate(_bulletPrefab, _firePoint.position, rotation);
            bullet.GetComponent<Bullet>().SetUp(_holder);
        }
    }
}
