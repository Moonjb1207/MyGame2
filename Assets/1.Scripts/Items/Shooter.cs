using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Weapon
{
    public Bullet bulletPrefab;

    public override void Attack()
    {
        StartCoroutine(shootingBullets(stat.shootingCount, stat.shootingDelay));
    }

    IEnumerator shootingBullets(int count, float delay)
    {
        IsAttacking = true;
        while (count != 0)
        {
            count--;
            Shooting();
            yield return new WaitForSeconds(delay);
        }
        IsAttacking = false;
    }

    public void Shooting()
    {
        Bullet bullet = Instantiate(bulletPrefab);

        bullet.transform.position = shootTr.position;
        bullet.Shoot(transform.forward, stat.Damage, stat.LifeTime, stat.moveSpeed);
    }
}
