using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMClearState_T : IGMState
{
    //�ǹ� ����
    GameObject[] tutorial_0 = new GameObject[5];
    //�ǹ� ��ü
    GameObject[] tutorial_1 = new GameObject[5];
    int curTutorial;

    public override void EnterState()
    {
        manager.buildButton.interactable = true;
        //building start
    }

    public override void UpdateState()
    {
        switch (curTutorial)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    void Tutorial_0()
    {

    }
}
