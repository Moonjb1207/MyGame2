using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Weapon
{
    public Bullet bulletPrefab;

    public override void Attack()
    {
        Bullet bullet = Instantiate(bulletPrefab);

        bullet.transform.position = transform.position;
        bullet.Shoot(transform.forward, stat.Damage);
    }
}
