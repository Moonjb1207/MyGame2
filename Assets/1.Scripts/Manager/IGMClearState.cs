using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMClearState : IGMState
{
    public override void EnterState()
    {
        InventoryManager.Instance.myGold += Player.Instance.myGold;

        Time.timeScale = 0.0f;
        //클리어 UI 띄우기
        IGUIManager.Instance.ClearUI.SetActive(true);
    }

    public override void UpdateState()
    {
        
    }
}
