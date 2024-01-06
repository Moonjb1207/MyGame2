using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ArmorStat
{
    public string equipName;
    public float equipmentSpeed;
    public float Damage;
    public int armorNum;

    public ArmorStat(string en, float asd, float dmg, int anm)
    {
        equipName = en;
        equipmentSpeed = asd;
        Damage = dmg;
        armorNum = anm;
}
}

[CreateAssetMenu(fileName = "ArmorStat Data", menuName = "ScriptableObject/ArmorStat Data", order = -1)]
public class ArmorData : ScriptableObject
{
    [SerializeField] ArmorStat[] armorStat;

    public ArmorStat[] armorStats
    {
        get => armorStat;
    }

    public ArmorStat getArmorStat(string equipName)
    {
        for (int i = 0; i < armorStat.Length; i++)
        {
            if (armorStat[i].equipName.Equals(equipName))
            {
                return armorStat[i];
            }
        }

        return null;
    }

    public string getEquipName(int i)
    {
        return armorStat[i].equipName;
    }
}