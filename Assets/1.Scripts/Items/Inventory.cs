using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Items> myItems = new List<Items>();
    public EquipName myHelmet;
    public EquipName myArmor;
    public WeaponName myWeapon;

    public void EquipWeapon_I(WeaponName weaponName)
    {
        myWeapon = weaponName;
    }

    public void EquipArmor_I(EquipName armorName)
    {
        myArmor = armorName;
    }
    public void EquipHelmet_I(EquipName helmetName)
    {
        myHelmet = helmetName;
    }

    public void AddItems(Items item)
    {
        myItems.Add(item);
    }
}
