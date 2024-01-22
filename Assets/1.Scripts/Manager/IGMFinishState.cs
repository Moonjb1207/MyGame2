using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMFinishState : IGMState
{
    float myTime = 10.0f;

    public override void EnterState()
    {
        remainTime = myTime;
        
        //attack end
    }

    public override void UpdateState()
    {
        remainTime -= Time.deltaTime;

        if(remainTime < 0)
        {
            if(manager.gameClear)
            {
                manager.NextState(manager.clearState);
            }

            manager.NextState(manager.buildingState);
        }
    }
}