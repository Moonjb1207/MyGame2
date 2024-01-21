using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMDefenseState : IGMState
{
    public override void EnterState()
    {
        for (int i = 0; i < manager.mySpawner.Length; i++)
        {
            manager.mySpawner[i].WaveStart(manager.stage);
            manager.spawnerCount++;
        }

        //attack start
        //building end
        manager.buildButton.interactable = false;

        if(manager.buildManagner.BuildState)
        {
            manager.buildManagner.ChangeBuildState();
        }
    }

    public override void UpdateState()
    {
        if(manager.spawnerCount == 0)
        {
            if(manager.wave == 0)
            {
                manager.gameClear = true;
            }

            manager.wave--;
            manager.NextState(manager.finishState);
        }
    }
}
