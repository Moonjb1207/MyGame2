using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Items
{
    public WeaponStat stat;
    public bool IsAttacking;
    public Transform shootTr;



    private void Start()
    {
        stat = WeaponManager.Instance.weaponData.getWeaponStat(stat.weaponName);
    }

    public abstract void Attack();
}