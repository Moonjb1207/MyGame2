using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    public EquipmentStat stat;

    private void Start()
    {
        stat = EquipmentManager.Instance.equipmentData.getEquipStat(stat.equipName);
    }
}
