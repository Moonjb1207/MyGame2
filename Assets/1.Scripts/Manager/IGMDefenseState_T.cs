using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMDefenseState_T : IGMState
{
    public List<GameObject> tutorials = new List<GameObject>();
    int curTutorial;

    [System.NonSerialized]
    bool firstBuild = false;

    public override void EnterState()
    {
        curTutorial = 0;
        manager.spawnerCount = 0;

        //for (int i = 0; i < manager.mySpawner.Length; i++)
        //{
        //    manager.mySpawner[i].WaveStart(manager.stage);
        //    manager.spawnerCount++;
        //}

        manager.buildButton.interactable = false;

        if (manager.buildManagner.BuildState)
        {
            manager.buildManagner.ChangeBuildState();
        }
    }

    public override void UpdateState()
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
                if (manager.tutoClear)
                {
                    NextTutorial();
                }
                break;
            case 4:
                break;
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

        tutorials[curTutorial].SetActive(true);
    }
}
