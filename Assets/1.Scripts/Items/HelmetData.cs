using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HelmetStat
{
    public int helmetNum;
    public float helmetSpeed;
    public float Damage;

    public HelmetStat(int hn, float hsd, float dmg)
    {
        helmetNum = hn;
        helmetSpeed = hsd;
        Damage = dmg;
    }
}

[CreateAssetMenu(fileName = "Helmet Data", menuName = "ScriptableObject/Helmet Data", order = -1)]
public class HelmetData : ScriptableObject
{
    [SerializeField] HelmetStat[] HelmetStat;

    public HelmetStat getHelmetStat(int i)
    {
        return HelmetStat[i];
    }
}