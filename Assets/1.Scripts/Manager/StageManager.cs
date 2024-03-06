using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    public static StageManager Instance => instance;

    public int stage;
    public Vector2 stageMinMax;

    public StageData data;

    public Button play;

    StageClearData saveData = new StageClearData();

    private void Awake()
    {
        if (instance == null)
            instance = this;

        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        if(!SaveManager.Instance.IsExist)
        {
            StageClearData data = new StageClearData();
            data.isUnlock[0] = true;
            data.isUnlock[1] = true;data.Gold = 0;

            for(int i = 2; i < data.isUnlock.Length; i++)
            {
                data.isUnlock[i] = false;
            }

            SaveManager.Instance.SaveFile<StageClearData>(SaveManager.Instance.StageSavefp, data);

            saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);
        }
        InventoryManager.Instance.myGold = saveData.Gold;

        stageMinMax = new Vector2(1, data.stageStats.Length);

        stage = 1;
    }

    void isCanPlay()
    {
        if (saveData.isUnlock[stage])
        {
            play.interactable = true;
        }
        else
        {
            play.interactable = false;
        }
    }

    public void UpStage()
    {
        stage++;
        if(stage >= stageMinMax.y)
        {
            stage = (int)stageMinMax.y - 1;
        }

        isCanPlay();
    }

    public void DownStage()
    {
        stage--;
        if (stage < stageMinMax.x)
        {
            stage = (int)stageMinMax.x;
        }

        isCanPlay();
    }
}
