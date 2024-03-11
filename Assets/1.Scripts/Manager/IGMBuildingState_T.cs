using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMBuildingState_T : IGMState
{
    public List<GameObject> tutorials = new List<GameObject>();
    int curTutorial;

    [System.NonSerialized]
    bool firstBuild = false;

    float myTime = 30.0f;

    public override void EnterState()
    {
        if (!firstBuild)
        {
            curTutorial = 0;
            manager.buildButton.interactable = true;
            tutorials[curTutorial].SetActive(true);

            InventoryManager.Instance.AddGold(100);
        }
        else
        {
            remainTime = myTime;
            manager.buildButton.interactable = true;
        }
    }

    public override void UpdateState()
    {
        if (!firstBuild)
        {
            switch (curTutorial)
            {
                case 0:
                    if (manager.tutoClear)
                    {
                        NextTutorial();
                    }
                    break;
                case 1:
                    if (manager.tutoClear)
                    {
                        NextTutorial();
                    }
                    break;
                case 2:
                    if (manager.tutoClear)
                    {
                        NextTutorial();
                    }
                    break;
                case 3:
                    if (InventoryManager.Instance.myGold <= 0)
                    {
                        NextTutorial();
                    }
                    break;
                case 4:
                    if (manager.tutoClear)
                    {
                        NextTutorial();
                    }
                    break;
                case 5:
                    if (manager.tutoClear)
                    {
                        NextTutorial();
                    }
                    break;
            }
        }
        else
        {
            remainTime -= Time.deltaTime;

            if (remainTime < 0)
            {
                manager.NextState(manager.defenseState);
            }
        }
    }

    public void NextTutorial()
    {
        tutorials[curTutorial].SetActive(false);
        manager.tutoClear = false;

        if (++curTutorial >= tutorials.Count)
        {
            firstBuild = true;
            manager.NextState(manager.defenseState);
            return;
        }

        tutorials[curTutorial].SetActive(true);
    }
}
