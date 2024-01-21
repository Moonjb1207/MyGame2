using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMBuildingState : IGMState
{
    float myTime = 30.0f;

    public override void EnterState()
    {
        remainTime = myTime;
        manager.buildButton.interactable = true;
        //building start
    }

    public override void UpdateState()
    {
        remainTime -= Time.deltaTime;

        if(remainTime < 0)
        {
            manager.NextState(manager.defenseState);
        }
    }
}
