using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance => instance;

    //public Dictionary<string, ItemType> myItems = new Dictionary<string, ItemType>();
    public Dictionary<ItemType, List<string>> myItemDic = new Dictionary<ItemType, List<string>>();
    public Dictionary<string, int> mybuildingDic = new Dictionary<string, int>();

    public string myHelmet;
    public string myArmor;
    public string myWeapon;

    public int myGold;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        myItemDic.Add(ItemType.weapon, new List<string>());
        myItemDic.Add(ItemType.armor, new List<string>());
        myItemDic.Add(ItemType.helmet, new List<string>());

        myHelmet = "none_helmet";
        myArmor = "none_armor";
        myWeapon = "knife";

        myItemDic[ItemType.weapon].Add(myWeapon);
        myItemDic[ItemType.armor].Add(myArmor);
        myItemDic[ItemType.helmet].Add(myHelmet);

        myGold = 0;
    }

    //public void EquipWeapon_I(string weaponName)
    //{
    //    myWeapon = weaponName;
    //}

    //public void EquipArmor_I(string armorName)
    //{
    //    myArmor = armorName;
    //}
    //public void EquipHelmet_I(string helmetName)
    //{
    //    myHelmet = helmetName;
    //}

    public void Equip(ItemType type, string equipName)
    {
        switch (type)
        {
            case ItemType.weapon:
                myWeapon = equipName;
                break;
            case ItemType.armor:
                myArmor = equipName;
                break;
            case ItemType.helmet:
                myHelmet = equipName;
                break;
        }
    }

    public void AddItems(string itemName, ItemType itemType)
    {
        if (myItemDic[itemType].Contains(itemName))
        {
            return;
        }

        myItemDic[itemType].Add(itemName);
    }

    public void AddBuildings(string buildingName)
    {
        if (mybuildingDic.ContainsKey(buildingName))
        {
            return;
        }

        mybuildingDic[buildingName] = 1;
    }

    public List<string> ShowEquipments(ItemType itemType)
    {
        if (!myItemDic.ContainsKey(itemType)) return null;

        return myItemDic[itemType];
    }
    
    public void AddGold(int add)
    {
        myGold += add;
    }

    public bool UseGold(int use)
    {
        if (myGold < use)
        {
            return false;
        }

        myGold -= use;
        return true;
    }
}
