using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUpgrade : MonoBehaviour
{
    public Image Img;
    public string myName;

    StageClearData saveData = new StageClearData();

    private void OnEnable()
    {
        //Img.sprite = EquipmentManager.Instance.GetBuildingStat(myName).myImg;
    }

    public void UpgradeBuilding()
    {
        //Upgrade
        int UpgradeCost = InventoryManager.Instance.mybuildingDic[myName] * 
            EquipmentManager.Instance.GetBuildingStat(myName).upgradeCost / 10;

        if(InventoryManager.Instance.CheckGold(UpgradeCost))
        {
            //추후에 확인UI 띄우고 구매로 변경
            WarningManager.Instance.ShowWarning(transform, 1);
            WarningManager.Instance.myEvent.AddListener(Upgrade);
        }
        else
        {
            //재화 부족 경고 생성
            WarningManager.Instance.ShowWarning(transform, 0);
        }
    }

    public void Upgrade()
    {
        int UpgradeCost = InventoryManager.Instance.mybuildingDic[myName] *
            EquipmentManager.Instance.GetBuildingStat(myName).upgradeCost / 10;

        InventoryManager.Instance.UseGold(UpgradeCost);
        InventoryManager.Instance.mybuildingDic[myName]++;

        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        saveData.Gold = InventoryManager.Instance.myGold;

        saveData.buildingLevel[EquipmentManager.Instance.GetBuildingStat(myName).buildingNum]
            = myName + "_" + InventoryManager.Instance.mybuildingDic[myName];

        SaveManager.Instance.SaveFile(SaveManager.Instance.StageSavefp, saveData);
    }

    public void setMyBuilding(string itemName)
    {
        myName = itemName;
    }

    public void setMyImg()
    {
        Img.sprite = EquipmentManager.Instance.GetBuildingStat(myName).myImg;
    }

    public void ShowInfo()
    {
        string name = myName;
        string ability = "HP : " + EquipmentManager.Instance.GetBuildingStat(myName).buildingHP.ToString();
        string aE = EquipmentManager.Instance.GetBuildingStat(myName).buildingInfo;
        string cost = "Cost : " + EquipmentManager.Instance.GetBuildingStat(myName).upgradeCost.ToString();

        InvenInfoUI.Instance?.setMyInfo(name, ability, aE, cost);
    }
}
