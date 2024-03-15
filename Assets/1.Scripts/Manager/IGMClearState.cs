using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMClearState : IGMState
{
    public override void EnterState()
    {
        Player.Instance.AddGold(100 * InGameManager.Instance.stage);

        InventoryManager.Instance.myGold += Player.Instance.myGold;
        StageManager.Instance.StageClearSave();

        Time.timeScale = 0.0f;
        //Ŭ���� UI ����
        IGUIManager.Instance.ClearUI.SetActive(true);
    }

    public override void UpdateState()
    {
        
    }
}
