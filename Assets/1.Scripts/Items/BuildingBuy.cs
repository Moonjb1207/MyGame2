using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBuy : MonoBehaviour
{
    public Image Img;
    public string myName;

    StageClearData saveData = new StageClearData();

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        //Img.sprite = EquipmentManager.Instance.GetBuildingStat(myName).myImg;
    }

    public void BuyBuilding()
    {
        //InventoryManager.Instance.AddBuildings(myName);
        int BuyCost = EquipmentManager.Instance.GetBuildingStat(myName).cost;

        if (InventoryManager.Instance.CheckGold(BuyCost))
        {
            //추후에 확인UI 띄우고 구매로 변경
            WarningManager.Instance.ShowWarning(transform, 1);
            WarningManager.Instance.myEvent.AddListener(Buy);
        }
        else
        {
            //재화 부족 경고 생성
            WarningManager.Instance.ShowWarning(transform, 0);
        }
    }

    public void Buy()
    {
        int BuyCost = EquipmentManager.Instance.GetBuildingStat(myName).cost;

        InventoryManager.Instance.UseGold(BuyCost);
        InventoryManager.Instance.AddBuildings(myName);

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
        //InfoUI myinfo = Instantiate(myInfo);

        string name = myName;
        string ability = "HP : " + EquipmentManager.Instance.GetBuildingStat(myName).buildingHP.ToString();
        string aE = EquipmentManager.Instance.GetBuildingStat(myName).buildingInfo;
        string cost = "Cost : " + EquipmentManager.Instance.GetBuildingStat(myName).cost.ToString();

        InfoUI.Instance.setMyInfo(name, ability, aE, cost);
    }
}
