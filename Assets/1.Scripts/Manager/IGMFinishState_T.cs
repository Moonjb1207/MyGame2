using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMFinishState_T : IGMFinishState
{
    //°Ç¹° Áþ±â
    public List<GameObject> tutorials = new List<GameObject>();
    public GameObject tutorial_2;

    int curTutorial;

    public override void EnterState()
    {
        if (manager.wave == 1)
        {
            curTutorial = 0;
            tutorials[curTutorial].SetActive(true);

            remainTime = myTime;
            IGUIManager.Instance.timeBar.fillAmount = remainTime / myTime;
        }
        else if (manager.wave == 0)
        {
            remainTime = myTime;
            IGUIManager.Instance.timeBar.fillAmount = remainTime / myTime;

            tutorial_2.SetActive(true);
        }
    }

    public override void UpdateState()
    {
        if (manager.wave == 1)
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
                    remainTime -= Time.deltaTime;
                    IGUIManager.Instance.timeBar.fillAmount = remainTime / myTime;

                    if (remainTime < 0)
                    {
                        NextTutorial();
                    }
                    break;
            }
        }
        else if (manager.wave == 0)
        {
            remainTime -= Time.deltaTime;
            IGUIManager.Instance.timeBar.fillAmount = remainTime / myTime;

            if (remainTime < 0)
            {
                if (manager.gameClear)
                {
                    manager.NextState(manager.clearState);
                }
            }
        }
    }

    public void NextTutorial()
    {
        tutorials[curTutorial].SetActive(false);
        manager.tutoClear = false;

        if (++curTutorial >= tutorials.Count)
        {
            manager.NextState(manager.buildingState);
            return;
        }

        tutorials[curTutorial].SetActive(true);
    }
}
