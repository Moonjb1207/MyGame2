using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMBuildingState : IGMState
{
    protected float myTime = 30.0f;

    public override void EnterState()
    {
        remainTime = myTime;
        IGUIManager.Instance.timeBar.fillAmount = remainTime / myTime;

        manager.buildButton.interactable = true;
        //building start

        if(StageManager.Instance.stage == 99)
        {
            Player.Instance.AddGold(100);
        }
        else
        {
            Player.Instance.myGold = InventoryManager.Instance.myGold;
        }
    }

    public override void UpdateState()
    {
        remainTime -= Time.deltaTime;
        IGUIManager.Instance.timeBar.fillAmount = remainTime / myTime;

        if (remainTime < 0)
        {
            manager.NextState(manager.defenseState);
        }
    }
}
