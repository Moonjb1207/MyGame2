using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGBuilding : MonoBehaviour, IBattle
{
    public string myName;
    public float curHP;
    public float Delay;
    public float SpeedDown;

    public void SetStat(string name)
    {
        myName = name;
        curHP = EquipmentManager.Instance.GetBuildingStat(myName).buildingHP
            + (InventoryManager.Instance.mybuildingDic[myName] - 1) * EquipmentManager.Instance.GetBuildingStat(myName).buildingHP / 10;
        Delay = EquipmentManager.Instance.GetBuildingStat(myName).delay;
        SpeedDown = EquipmentManager.Instance.GetBuildingStat(myName).speedDown;
    }

    public void OnDamage(float dmg)
    {
        if (curHP > 0)
            curHP -= dmg;

        if (curHP <= 0)
        {
            Destroy(this);
        }
    }

    public void AddExp(int exp)
    {

    }

    public void AddGold(int gold)
    {

    }

    public bool IsLive
    {
        get;
    }
}