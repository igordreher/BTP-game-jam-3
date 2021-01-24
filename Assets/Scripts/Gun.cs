using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float fireRate;
    [SerializeField] int clipSize;
    GameObject _holder;

    public void Initialize(GameObject holder)
    {
        _holder = holder;
    }

    public void Shoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetUp(_holder);
    }

}