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
        //Img = 
    }
    
    public void BuyBuilding()
    {
        InventoryManager.Instance.AddBuildings(myName);
    }

    public void setMyBuilding(string itemName)
    {
        myName = itemName;
    }
}
