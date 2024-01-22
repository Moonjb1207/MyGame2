using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingEquip : MonoBehaviour
{
    public Image Img;
    public string myName;

    private void Awake()
    {
        //Img = 
    }

    public void EquipBuilding()
    {
        InventoryManager.Instance.EquipBuilding(myName);
    }

    public void setMyBuilding(string itemName)
    {
        myName = itemName;
    }
}
