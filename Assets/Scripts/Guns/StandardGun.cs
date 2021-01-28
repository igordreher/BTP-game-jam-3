using UnityEngine;

public class StandardGun : Gun
{
    public StandardGun(Transform firePoint, GameObject holder, GameObject bulletPrefab) : base(firePoint, holder, bulletPrefab)
    { }

    public override void Shoot()
    {
        if (Time.time < _nextFireTime)
            return;
        _nextFireTime = Time.time + 1 / FireRate;

        GameObject bullet = MonoBehaviour.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Bullet>().SetUp(_holder);
    }
}