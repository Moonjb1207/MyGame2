using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponName weaponName;
    public WeaponStat stat;

    public abstract void Attack();
}

public enum WeaponName
{
    knife,
    machete,
    colt,
    awp
}