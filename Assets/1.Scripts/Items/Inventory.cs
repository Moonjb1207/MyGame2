using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemName> myItems = new List<ItemName>();
    public ItemName myHelmet;
    public ItemName myArmor;
    public ItemName myWeapon;

    private void Awake()
    {
        myItems.Add(ItemName.knife);
        myItems.Add(ItemName.none_helmet);
        myItems.Add(ItemName.none_armor);

        myHelmet = ItemName.none_helmet;
        myArmor = ItemName.none_armor;
        myWeapon = ItemName.knife;
    }

    public void EquipWeapon_I(ItemName weaponName)
    {
        myWeapon = weaponName;
    }

    public void EquipArmor_I(ItemName armorName)
    {
        myArmor = armorName;
    }
    public void EquipHelmet_I(ItemName helmetName)
    {
        myHelmet = helmetName;
    }

    public void AddItems(ItemName itemName)
    {
        for(int i = 0; i < myItems.Count; i++)
        {
            if (myItems[i] == itemName)
            {
                return;
            }
        }

        myItems.Add(itemName);
    }

    public List<ItemName> showWeapons()
    {
        List<ItemName> weapons = new List<ItemName>();
        for(int i = 0; i < myItems.Count; i++)
        {
            if(myItems[i] < ItemName.weaponEnd)
            {
                weapons.Add(myItems[i]);
            }
        }

        return weapons;
    }

    public List<ItemName> showArmors()
    {
        List<ItemName> armors = new List<ItemName>();
        for (int i = 0; i < myItems.Count; i++)
        {
            if (myItems[i] < ItemName.armorEnd && myItems[i] > ItemName.weaponEnd)
            {
                armors.Add(myItems[i]);
            }
        }

        return armors;
    }

    public List<ItemName> showHelmets()
    {
        List<ItemName> helmets = new List<ItemName>();
        for (int i = 0; i < myItems.Count; i++)
        {
            if (myItems[i] < ItemName.helmetEnd && myItems[i] > ItemName.armorEnd)
            {
                helmets.Add(myItems[i]);
            }
        }

        return helmets;
    }
}
