using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    private static EquipmentManager instance;
    public static EquipmentManager Instance => instance;

    public ArmorData armorData;
    public HelmetData helmetData;
    public WeaponData weaponData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
