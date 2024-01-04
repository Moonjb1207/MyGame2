using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Image Img;
    public ItemName myName;

    private void Awake()
    {
        //Img = 
    }

    public void SelectItem()
    {
        if(myName < ItemName.weaponEnd)
        {
            InventoryManager.Instance.myInven.EquipWeapon_I(myName);
            MainPlayer.Instance.EquipWeapon(myName);
        }
        else if(myName < ItemName.armorEnd)
        {
            InventoryManager.Instance.myInven.EquipArmor_I(myName);
            MainPlayer.Instance.EquipArmor(myName);
        }
        else if(myName < ItemName.helmetEnd)
        {
            InventoryManager.Instance.myInven.EquipHelmet_I(myName);
            MainPlayer.Instance.EquipHelmet(myName);
        }
    }

    public void setMyName(ItemName itemName)
    {
        myName = itemName;
    }
}
