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
        string aE = "";

        InfoUI.Instance.setMyInfo(name, ability, aE);
    }
}
