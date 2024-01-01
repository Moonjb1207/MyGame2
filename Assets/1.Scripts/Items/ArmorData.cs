using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ArmorStat
{
    public int armorNum;
    public float armorSpeed;
    public float Damage;

    public ArmorStat(int an, float asd, float dmg)
    {
        armorNum = an;
        armorSpeed = asd;
        Damage = dmg;
    }
}

[CreateAssetMenu(fileName = "Armor Data", menuName = "ScriptableObject/Armor Data", order = -1)]
public class ArmorData : ScriptableObject
{
    [SerializeField] ArmorStat[] armorStat;

    public ArmorStat getArmorStat(int i)
    {
        return armorStat[i];
    }
}
