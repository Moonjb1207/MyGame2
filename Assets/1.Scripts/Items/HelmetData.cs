using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HelmetStat
{
    public ItemName equipName;
    public float equipmentSpeed;
    public float Damage;

    public HelmetStat(ItemName an, float asd, float dmg)
    {
        equipName = an;
        equipmentSpeed = asd;
        Damage = dmg;
    }
}

[CreateAssetMenu(fileName = "Helmet Data", menuName = "ScriptableObject/Helmet Data", order = -1)]
public class HelmetData : ScriptableObject
{
    [SerializeField] HelmetStat[] helmetStat;

    public HelmetStat getHelmetStat(ItemName equipName)
    {
        return helmetStat[(int)equipName - (int)ItemName.armorEnd - 1];
    }
}