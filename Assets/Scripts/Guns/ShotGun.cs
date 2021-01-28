using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public ShotGun(Transform firePoint, GameObject holder, GameObject bulletPrefab) : base(firePoint, holder, bulletPrefab)
    { }

    public override void Shoot()
    {
        if (Time.time < _nextFireTime)
            return;
        _nextFireTime = Time.time + 1 / FireRate;

        ShootThreeBullets();
    }

    void ShootThreeBullets()
    {
        Quaternion rotation = _firePoint.rotation;
        for (int i = -1; i < 2; i++)
        {
            float offset = i * 15f;
            rotation = Quaternion.Euler(_firePoint.eulerAngles.x, _firePoint.eulerAngles.y, _firePoint.eulerAngles.z + offset);
            GameObject bullet = MonoBehaviour.Instantiate(_bulletPrefab, _firePoint.position, rotation);
            bullet.GetComponent<Bullet>().SetUp(_holder);
        }
    }
}
