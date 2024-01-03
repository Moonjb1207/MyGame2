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
        }
        else if (itemName < ItemName.armorEnd)
        {
            infoText.text = "���� ����!!";
        }
        else if (itemName < ItemName.helmetEnd)
        {
            infoText.text = "���� ���!!";
        }
    }

    public void Back()
    {
        gameObject.SetActive(false);
        store.gameObject.SetActive(true);
    }
}
