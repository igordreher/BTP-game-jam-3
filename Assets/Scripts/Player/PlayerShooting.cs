using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _primaryGunFireRate;
    [SerializeField] float _secundaryGunFireRate;
    Gun _primaryGun;
    Gun _secundaryGun;
    Transform _firePoint;

    void Awake()
    {
        _firePoint = GetComponentInChildren<Transform>();
    }

    void Start()
    {
        _primaryGun = new StandardGun(_firePoint, gameObject, _bulletPrefab);
        _secundaryGun = new ShotGun(_firePoint, gameObject, _bulletPrefab);

        _primaryGun.FireRate = _primaryGunFireRate;
        _secundaryGun.FireRate = _secundaryGunFireRate;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            _primaryGun.Shoot();
        else if (Input.GetMouseButton(1))
            _secundaryGun.Shoot();
    }
}
