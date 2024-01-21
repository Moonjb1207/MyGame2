using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HelmetStat
{
    public string equipName;
    public Vector2 equipmentSight;
    public float Damage;
    public int helNum;

    public HelmetStat(string en, Vector2 asd, float dmg, int hnm)
    {
        equipName = en;
        equipmentSight = asd;
        Damage = dmg;
        helNum = hnm;
    }
}

[CreateAssetMenu(fileName = "Helmet Data", menuName = "ScriptableObject/Helmet Data", order = -1)]
public class HelmetData : ScriptableObject
{
    [SerializeField] HelmetStat[] helmetStat;

    public HelmetStat[] helmetStats
    {
        get => helmetStat;
    }

    public HelmetStat getHelmetStat(string equipName)
    {
        return EquipmentManager.Instance.GetHelmetStat(equipName);

        //for (int i = 0; i < helmetStat.Length; i++)
        //{
        //    if (helmetStat[i].equipName.Equals(equipName))
        //    {
        //        return helmetStat[i];
        //    }
        //}

        //return null;
    }
}