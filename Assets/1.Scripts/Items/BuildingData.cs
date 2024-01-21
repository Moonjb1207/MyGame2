using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BuildingStat
{
    public string buildingName;
    public float buildingHP;
    public float speedDown;
    public float delay;
    public int cost;
    public int upgradeCost;

    public BuildingStat(string bn, float hp, float sd, float d, int c, int uc)
    {
        buildingName = bn;
        buildingHP = hp;
        speedDown = sd;
        delay = d;
        cost = c;
        upgradeCost = uc;
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
