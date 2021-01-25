﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun
{
    protected float _fireRate;
    protected float _nextFireTime;
    protected Transform _firePoint;
    protected GameObject _bulletPrefab;
    protected GameObject _holder;

    protected Gun(Transform firePoint, GameObject holder, GameObject bulletPrefab)
    {
        _firePoint = firePoint;
        _holder = holder;
        _bulletPrefab = bulletPrefab;
        _nextFireTime = 0;
    }

    public virtual void Shoot()
    { }
}
