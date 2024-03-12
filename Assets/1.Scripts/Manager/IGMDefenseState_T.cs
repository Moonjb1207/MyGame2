using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMDefenseState_T : IGMDefenseState
{
    public List<GameObject> tutorials = new List<GameObject>();
    public GameObject tutorial_2;

    int curTutorial;

    public override void EnterState()
    {
        manager.spawnerCount = 0;

        manager.buildButton.interactable = false;
        if (manager.buildManagner.BuildState)
        {
            manager.buildManagner.ChangeBuildState();
        }


        if (manager.wave == 2)
        {
            curTutorial = 0;
            tutorials[curTutorial].SetActive(true);
        }
        else if (manager.wave == 1)
        {
            for (int i = 0; i < manager.mySpawner.Length; i++)
            {
                manager.mySpawner[i].WaveStart(manager.stage);
                manager.spawnerCount++;
            }

            tutorial_2.SetActive(true);
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
                        for (int i = 0; i < manager.mySpawner.Length; i++)
                        {
                            manager.mySpawner[i].WaveStart(manager.stage);
                            manager.spawnerCount++;
                        }
                        NextTutorial();
                    }
                    break;
                case 2:
                    if (manager.spawnerCount == 0)
                    {
                        NextTutorial();
                    }
                    break;
                case 3:
                    if (manager.tutoClear)
                    {
                        NextTutorial();
                    }
                    break;
            }
        }
        else if (manager.wave == 1)
        {
            if (manager.spawnerCount == 0)
            {
                if (--manager.wave == 0)
                {
                    manager.gameClear = true;
                }

                tutorial_2.SetActive(false);
                manager.NextState(manager.finishState);
            }
        }
    }

    public void NextTutorial()
    {
        tutorials[curTutorial].SetActive(false);
        manager.tutoClear = false;

        if (++curTutorial >= tutorials.Count)
        {
            manager.NextState(manager.finishState);
            return;
        }

        tutorials[curTutorial].SetActive(true);
    }
}
