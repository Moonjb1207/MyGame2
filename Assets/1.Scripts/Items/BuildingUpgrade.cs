using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUpgrade : MonoBehaviour
{
    public Image Img;
    public string myName;


    private void OnEnable()
    {
        Img.sprite = EquipmentManager.Instance.GetBuildingStat(myName).myImg;
    }

    public void UpgradeBuilding()
    {
        //Upgrade
        int UpgradeCost = InventoryManager.Instance.mybuildingDic[myName] * 
            EquipmentManager.Instance.GetBuildingStat(myName).upgradeCost / 10;

        if(InventoryManager.Instance.CheckGold(UpgradeCost))
        {
            //���Ŀ� Ȯ��UI ���� ���ŷ� ����
            WarningManager.Instance.ShowWarning(transform, 1);
            WarningManager.Instance.myEvent.AddListener(Upgrade);
        }
        else
        {
            //��ȭ ���� ��� ����
            WarningManager.Instance.ShowWarning(transform, 0);
        }
    }

    public void Upgrade()
    {
        int UpgradeCost = InventoryManager.Instance.mybuildingDic[myName] *
            EquipmentManager.Instance.GetBuildingStat(myName).upgradeCost / 10;

        InventoryManager.Instance.UseGold(UpgradeCost);
        InventoryManager.Instance.mybuildingDic[myName]++;
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