using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreResult : MonoBehaviour
{
    public Image resultImg;
    public TMPro.TMP_Text infoText;
    public TMPro.TMP_Text resultText;

    public void ShowResult(string itemName, ItemType itemType)
    {
        gameObject.SetActive(true);
        if (itemType == ItemType.weapon)
        {
            infoText.text = "ªÃ¿∫ π´±‚!!";
            resultText.text = "√‡«œ«’¥œ¥Ÿ!! : " + EquipmentManager.Instance.weaponData.getWeaponStat(itemName).weaponName.ToString();
        }
        else if (itemType == ItemType.armor)
        {
            infoText.text = "ªÃ¿∫ ∞©ø !!";
            resultText.text = "√‡«œ«’¥œ¥Ÿ!! : " + EquipmentManager.Instance.armorData.getArmorStat(itemName).equipName.ToString();
        }
        else if (itemType == ItemType.helmet)
        {
            infoText.text = "ªÃ¿∫ «Ô∏‰!!";
            resultText.text = "√‡«œ«’¥œ¥Ÿ!! : " + EquipmentManager.Instance.helmetData.getHelmetStat(itemName).equipName.ToString();
        }
    }
}
