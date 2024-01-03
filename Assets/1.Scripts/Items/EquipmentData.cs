using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EquipmentStat
{
    public EquipName equipName;
    public float equipmentSpeed;
    public float Damage;

    public EquipmentStat(EquipName an, float asd, float dmg)
    {
        equipName = an;
        equipmentSpeed = asd;
        Damage = dmg;
    }
}

[CreateAssetMenu(fileName = "EquipmentStat Data", menuName = "ScriptableObject/EquipmentStat Data", order = -1)]
public class EquipmentData : ScriptableObject
{
    [SerializeField] EquipmentStat[] equipmentStat;

    public EquipmentStat getEquipStat(EquipName equipName)
    {
        return equipmentStat[(int)equipName];
    }
}

public enum EquipName
{
    none_armor,
    lv1_armor,
    lv2_armor,
    lv3_armor,
    none_helmet,
    lv1_helmet,
    lv2_helmet,
    lv3_helmet,
    End,
}