using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreResult : MonoBehaviour
{
    public Image resultImg;
    public TMPro.TMP_Text infoText;
    public TMPro.TMP_Text resultText;

    public Store store;

    public void ShowResult(ItemName itemName)
    {
        gameObject.SetActive(true);
        if (itemName < ItemName.weaponEnd)
        {
            infoText.text = "���� ����!!";
            resultText.text = "�����մϴ�!! : " + WeaponManager.Instance.weaponData.getWeaponStat(itemName).weaponName.ToString();
        }
        else if (itemName < ItemName.armorEnd)
        {
            infoText.text = "���� ����!!";
            resultText.text = "�����մϴ�!! : " + EquipmentManager.Instance.armorData.getArmorStat(itemName).equipName.ToString();
        }
        else if (itemName < ItemName.helmetEnd)
        {
            infoText.text = "���� ���!!";
            resultText.text = "�����մϴ�!! : " + EquipmentManager.Instance.helmetData.getHelmetStat(itemName).equipName.ToString();
        }
    }
}
