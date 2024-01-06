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
        //Img = 
    }

    public void SelectItem()
    {
        if (myType == ItemType.weapon)
        {
            InventoryManager.Instance.myInven.EquipWeapon_I(myName);
            MainPlayer.Instance.EquipWeapon(myName);
        }
        else if(myType == ItemType.armor)
        {
            InventoryManager.Instance.myInven.EquipArmor_I(myName);
            MainPlayer.Instance.EquipArmor(myName);
        }
        else if(myType == ItemType.helmet)
        {
            InventoryManager.Instance.myInven.EquipHelmet_I(myName);
            MainPlayer.Instance.EquipHelmet(myName);
        }
    }

    public void setMyName(string itemName)
    {
        myName = itemName;
    }
}
