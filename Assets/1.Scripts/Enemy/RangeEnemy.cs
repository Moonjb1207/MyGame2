using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    public RangeWeapon weaponPrefab;
    public Transform shootTr;

    public override void OnAttack()
    {
        Shooting();
        curEnemyState.myAnim.SetTrigger("Attacking");
    }

    public void Shooting()
    {
        RangeWeapon myWeapon = Instantiate(weaponPrefab);

        myWeapon.transform.position = shootTr.position;
        myWeapon.Shoot(transform.forward, data.damage, 3, 4);
        //bullet.gameObject.SetActive(true);
    }
}
