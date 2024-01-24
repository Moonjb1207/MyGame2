using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMClearState : IGMState
{
    public override void EnterState()
    {
        InventoryManager.Instance.myGold += Player.Instance.myGold;
    }

    public override void UpdateState()
    {
        
    }
}
