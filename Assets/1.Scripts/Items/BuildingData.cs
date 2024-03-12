using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BuildingStat
{
    public string buildingName;
    public float buildingHP;
    public float value;
    public float delay;
    public float keepTime;
    public float damageTime;
    public int cost;
    public int upgradeCost;
    public int buildingCost;
    public Sprite myImg;

    public BuildingStat(string bn, float hp, float v, float d, float kt, float dt, int c, int uc, int bc, Sprite i)
    {
        buildingName = bn;
        buildingHP = hp;
        value = v;
        delay = d;
        keepTime = kt;
        damageTime = dt;
        cost = c;
        upgradeCost = uc;
        buildingCost = bc;
        myImg = i;
    }
}


[CreateAssetMenu(fileName = "BuildingStat Data", menuName = "ScriptableObject/BuildingStat Data", order = -1)]
public class BuildingData : ScriptableObject
{
    [SerializeField] BuildingStat[] buildingStat;

    public BuildingStat[] buildingStats
    {
        get => buildingStat;
    }

    public BuildingStat getBuildingStat(string buildingname)
    {
        return EquipmentManager.Instance.GetBuildingStat(buildingname);
    }
}
