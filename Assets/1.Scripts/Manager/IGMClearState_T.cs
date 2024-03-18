using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMClearState_T : IGMClearState
{
    public GameObject tutorial;

    public override void EnterState()
    {
        Player.Instance.AddGold(500);
        InventoryManager.Instance.myGold += Player.Instance.myGold;


        StageManager.Instance.TutorialStageClear();

        tutorial.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public override void UpdateState()
    {
        
    }
}
