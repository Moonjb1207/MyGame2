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
            infoText.text = "»ÌÀº ¹«±â!!";
            resultText.text = "ÃàÇÏÇÕ´Ï´Ù!! : " + WeaponManager.Instance.weaponData.getWeaponStat(itemName).weaponName.ToString();
        }
        else if (itemName < ItemName.armorEnd)
        {
            infoText.text = "»ÌÀº °©¿Ê!!";
            resultText.text = "ÃàÇÏÇÕ´Ï´Ù!! : " + EquipmentManager.Instance.armorData.getArmorStat(itemName).equipName.ToString();
        }
        else if (itemName < ItemName.helmetEnd)
        {
            infoText.text = "»ÌÀº Çï¸ä!!";
            resultText.text = "ÃàÇÏÇÕ´Ï´Ù!! : " + EquipmentManager.Instance.helmetData.getHelmetStat(itemName).equipName.ToString();
        }
    }
}
