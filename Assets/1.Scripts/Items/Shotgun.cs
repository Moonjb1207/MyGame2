using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
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
        for(int i = -1; i < 2; i++)
        {
            Bullet bullet = BulletPool.Instance.DequeueBullet();

            bullet.transform.position = shootTr.position;
            bullet.Shoot(transform.forward + new Vector3(i * 0.3f, 0, 0), stat.Damage, stat.LifeTime, stat.moveSpeed);
            bullet.gameObject.SetActive(true);
        }
    }
}
