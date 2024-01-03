using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHelmet : Equipment
{
    public HelmetStat stat;

    private void Start()
    {
        stat = EquipmentManager.Instance.helmetData.getHelmetStat(stat.equipName);
    }
}
