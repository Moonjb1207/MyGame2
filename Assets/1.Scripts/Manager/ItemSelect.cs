using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Image Img;
    public string myName;
    public ItemType myType;
    public TMPro.TMP_Text equiping;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public void SelectItem()
    {
        InventoryManager.Instance.Equip(myType, myName);
        Player.Instance?.EquipItem(myType, myName);

        GetComponentInParent<MainEquipmentContainer>().LoadEquipment();
    }

    public void setMyButton()
    {
        if (myType == ItemType.weapon)
        {
            if (myName == InventoryManager.Instance.myWeapon)
            {
                equiping.text = "ÀåÂø Áß";
            }
            else
            {
                equiping.text = "Àå Âø";
            }
        }
        else if (myType == ItemType.armor)
        {
            if (myName == InventoryManager.Instance.myArmor)
            {
                equiping.text = "ÀåÂø Áß";
            }
            else
            {
                equiping.text = "Àå Âø";
            }
        }
        else if (myType == ItemType.helmet)
        {
            if (myName == InventoryManager.Instance.myHelmet)
            {
                equiping.text = "ÀåÂø Áß";
            }
            else
            {
                equiping.text = "Àå Âø";
            }
        }
    }

    public void setMyItem(string itemName, ItemType itemType)
    {
        myType = itemType;
        myName = itemName;
    }

    public void setImg()
    {
        if (myType == ItemType.weapon)
        {
            Img.sprite = EquipmentManager.Instance.GetWeaponStat(myName).myImg;
        }
        else if (myType == ItemType.armor)
        {
            Img.sprite = EquipmentManager.Instance.GetArmorStat(myName).myImg;
        }
        else if (myType == ItemType.helmet)
        {
            Img.sprite = EquipmentManager.Instance.GetHelmetStat(myName).myImg;
        }
    }

    public void ShowInfo()
    {
        string name = myName;
        string aE = "";
        string cost = "";

        string ability = "";
        if (myType == ItemType.weapon)
        {
            ability = "Atk : " + EquipmentManager.Instance.GetWeaponStat(myName).Damage.ToString();
        }
        else if (myType == ItemType.armor)
        {
            ability = "Dmg Reduce : " + EquipmentManager.Instance.GetArmorStat(myName).Damage.ToString();
            aE = EquipmentManager.Instance.GetArmorStat(myName).equipInfo;
        }
        else if (myType == ItemType.helmet)
        {
            ability = "Dmg Reduce : " + EquipmentManager.Instance.GetHelmetStat(myName).Damage.ToString();
            aE = EquipmentManager.Instance.GetHelmetStat(myName).equipInfo;
        }

        InvenInfoUI.Instance?.setMyInfo(name, ability, aE, cost);
    }
}
