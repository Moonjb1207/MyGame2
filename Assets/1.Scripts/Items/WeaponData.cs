using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponStat
{
    public int weaponNum;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;
    public float shootingDelay;
    public int shootingCount;
    public float attackDelay;
    public float meleeDamage;

    public WeaponStat(int wn, float lt, float ms, float dmg, float shd, int shc, float ad, float md)
    {
        weaponNum = wn;
        LifeTime = lt;
        moveSpeed = ms;
        Damage = dmg;
        shootingDelay = shd;
        shootingCount = shc;
        attackDelay = ad;
        meleeDamage = md;
    }
}

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObject/Weapon Data", order = -1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] WeaponStat[] weaponStat;

    public WeaponStat getWeaponStat(int i)
    {
        return weaponStat[i];
    }
}
