using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Weapon
{
    public Bullet bulletPrefab;

    public override void Attack()
    {
        Bullet bullet = Instantiate(bulletPrefab);

        bullet.transform.position = shootTr.position;
        bullet.Shoot(transform.forward, stat.Damage, stat.LifeTime, stat.moveSpeed);
    }

    IEnumerator shootingBullets(int count, float delay)
    {
        IsAttacking = true;
        while (count != 0)
        {
            count--;
            Attack();
            yield return new WaitForSeconds(delay);
        }
        IsAttacking = false;
    }

    public void Shooting()
    {
        StartCoroutine(shootingBullets(stat.shootingCount, stat.shootingDelay));
    }
}
