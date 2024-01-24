using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Image Img;
    public string myName;
    public ItemType myType;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        if(myType == ItemType.weapon)
        {
            Img.sprite = EquipmentManager.Instance.GetWeaponStat(myName).myImg;
        }
        else if(myType == ItemType.armor)
        {
            Img.sprite = EquipmentManager.Instance.GetArmorStat(myName).myImg;
        }
        else if(myType == ItemType.helmet)
        {
            Img.sprite = EquipmentManager.Instance.GetHelmetStat(myName).myImg;
        }
    }

    public void SelectItem()
    {
        InventoryManager.Instance.Equip(myType, myName);
        Player.Instance?.EquipItem(myType, myName);
    }

    public void setMyItem(string itemName, ItemType itemType)
    {
        myName = itemName;
        myType = itemType;
    }

    public void setImg()
    {
        if (myType == ItemType.weapon)
        {
            Img.sprite = EquipmentManager.Instance.GetWeaponStat(myName).myImg;
        }
        else if (myType == ItemType.armor)
        {
            Img.sprite = EquipmentManager.Instance.GetArmorStat(myName).myImg;
        }
        else if (myType == ItemType.helmet)
        {
            Img.sprite = EquipmentManager.Instance.GetHelmetStat(myName).myImg;
        }
    }
}
