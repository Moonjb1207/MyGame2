using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipArmor : Equipment
{
    public ArmorStat stat;

    private void Start()
    {
        stat = EquipmentManager.Instance.armorData.getArmorStat(stat.equipName);
    }
}
