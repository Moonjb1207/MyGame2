using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ArmorStat
{
    public ItemName equipName;
    public float equipmentSpeed;
    public float Damage;

    public ArmorStat(ItemName an, float asd, float dmg)
    {
        equipName = an;
        equipmentSpeed = asd;
        Damage = dmg;
    }
}

[CreateAssetMenu(fileName = "ArmorStat Data", menuName = "ScriptableObject/ArmorStat Data", order = -1)]
public class ArmorData : ScriptableObject
{
    [SerializeField] ArmorStat[] armorStat;

    public ArmorStat getArmorStat(ItemName equipName)
    {
        return armorStat[(int)equipName - (int)ItemName.weaponEnd - 1];
    }
}