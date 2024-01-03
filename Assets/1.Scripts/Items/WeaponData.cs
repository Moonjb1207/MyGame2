using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponStat
{
    public WeaponName weaponName;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;
    public float shootingDelay;
    public int shootingCount;
    public float meleeDamage;

    public WeaponStat(WeaponName wn, float lt, float ms, float dmg, float shd, int shc, float md)
    {
        weaponName = wn;
        LifeTime = lt;
        moveSpeed = ms;
        Damage = dmg;
        shootingDelay = shd;
        shootingCount = shc;
        meleeDamage = md;
    }
}

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObject/Weapon Data", order = -1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] WeaponStat[] weaponStat;

    public WeaponStat getWeaponStat(WeaponName weaponName)
    {
        return weaponStat[(int)weaponName];
    }
}

public enum WeaponName
{
    knife,
    machete,
    colt,
    shotgun,
    m4a1,
    ak47,
    aug,
    famas,
    awp,
    End
}
