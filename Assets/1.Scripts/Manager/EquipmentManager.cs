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

        InitData();
    }

    Dictionary<string, ArmorStat> armorStatDic = new Dictionary<string, ArmorStat>();
    Dictionary<string, HelmetStat> helmetStatDic = new Dictionary<string, HelmetStat>();
    Dictionary<string, WeaponStat> weaponStatDic = new Dictionary<string, WeaponStat>();

    void InitData()
    {
        for(int i = 0; i < armorData.armorStats.Length; i++)
        {
            armorStatDic.Add(armorData.armorStats[i].equipName, armorData.armorStats[i]);
        }

        for (int i = 0; i < helmetData.helmetStats.Length; i++)
        {
            helmetStatDic.Add(helmetData.helmetStats[i].equipName, helmetData.helmetStats[i]);
        }

        for (int i = 0; i < weaponData.weaponStats.Length; i++)
        {
            weaponStatDic.Add(weaponData.weaponStats[i].weaponName, weaponData.weaponStats[i]);
        }
    }

    public ArmorStat GetArmorStat(string ename)
    {
        if (!armorStatDic.ContainsKey(ename)) return null;

        return armorStatDic[ename];
    }

    public HelmetStat GetHelmetStat(string ename)
    {
        if (!helmetStatDic.ContainsKey(ename)) return null;

        return helmetStatDic[ename];
    }

    public WeaponStat GetWeaponStat(string ename)
    {
        if (!weaponStatDic.ContainsKey(ename)) return null;

        return weaponStatDic[ename];
    }
}
