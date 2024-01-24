using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBuy : MonoBehaviour
{
    public Image Img;
    public string myName;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        Img.sprite = EquipmentManager.Instance.GetBuildingStat(myName).myImg;
    }

    public void BuyBuilding()
    {
        InventoryManager.Instance.AddBuildings(myName);
    }

    public void setMyBuilding(string itemName)
    {
        myName = itemName;
    }

    public void setMyImg()
    {
        Img.sprite = EquipmentManager.Instance.GetBuildingStat(myName).myImg;
    }
}
