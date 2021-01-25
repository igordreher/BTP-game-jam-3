using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public ShotGun(Transform firePoint, GameObject holder, GameObject bulletPrefab) : base(firePoint, holder, bulletPrefab)
    {
        _fireRate = 1;
    }

    public override void Shoot()
    {
        if (Time.time < _nextFireTime)
            return;
        _nextFireTime = Time.time + 1 / _fireRate;

        ShootThreeBullets();
    }

    void ShootThreeBullets()
    {
        Quaternion rotation = _firePoint.rotation;
        for (int i = -1; i < 2; i++)
        {
            float offset = i * 25f;
            rotation = Quaternion.Euler(_firePoint.eulerAngles.x, _firePoint.eulerAngles.y, _firePoint.eulerAngles.z + offset);
            GameObject bullet = MonoBehaviour.Instantiate(_bulletPrefab, _firePoint.position, rotation);
            bullet.GetComponent<Bullet>().SetUp(_holder);
        }
    }
}
