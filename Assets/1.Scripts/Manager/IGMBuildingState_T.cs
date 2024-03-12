using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMBuildingState_T : IGMBuildingState
{
    public List<GameObject> tutorials = new List<GameObject>();
    public GameObject tutorial_2;
    int curTutorial;

    public override void EnterState()
    {
        manager.buildButton.interactable = true;

        if (manager.wave == 2)
        {
            curTutorial = 0;
            tutorials[curTutorial].SetActive(true);

            Player.Instance.AddGold(100);
        }
        else if (manager.wave == 1)
        {
            tutorial_2.SetActive(true);

            remainTime = myTime;

            Player.Instance.AddGold(100);
        }
    }

    public override void UpdateState()
    {
        if (manager.wave == 2)
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
                    if (Player.Instance.myGold <= 0)
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
            }
        }
        else if (manager.wave == 1)
        {
            remainTime -= Time.deltaTime;

            if (remainTime < 0)
            {
                tutorial_2.SetActive(false);
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
            manager.NextState(manager.defenseState);
            return;
        }

        tutorials[curTutorial]?.SetActive(true);
    }
}