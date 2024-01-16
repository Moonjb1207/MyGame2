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
        InventoryManager.Instance.Equip(myType, myName);
        Player.Instance?.EquipItem(myType, myName);
    }

    public void setMyItem(string itemName, ItemType itemType)
    {
        myName = itemName;
        myType = itemType;
    }
}
