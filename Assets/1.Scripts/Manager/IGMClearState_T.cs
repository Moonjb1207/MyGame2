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

        Time.timeScale = 0.0f;

        tutorial.SetActive(true);
    }

    public override void UpdateState()
    {
        
    }
}
