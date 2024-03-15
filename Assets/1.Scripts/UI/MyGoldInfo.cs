using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGoldInfo : MonoBehaviour
{
    TMPro.TMP_Text gold;

    int i_gold;

    private void Awake()
    {
        gold = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        if(i_gold != InventoryManager.Instance.myGold)
        {
            ChangeTxt();
        }
    }

    private void OnEnable()
    {
        ChangeTxt();
    }

    void ChangeTxt()
    {
        i_gold = InventoryManager.Instance.myGold;

        gold.text = "Gold : " + i_gold;
    }
}
