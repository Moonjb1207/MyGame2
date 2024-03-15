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

    }

    private void Start()
    {
        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        if (!SaveManager.Instance.IsExist)
            CreateSaveFile();

        InventoryManager.Instance.myGold = saveData.Gold;

        stageMinMax = new Vector2(0, data.stageStats.Length);

        stage = 0;
    }
    
    public void StageClearSave()
    {
        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        saveData.Gold = InventoryManager.Instance.myGold;
        saveData.isUnlock[stage + 1] = true;

        SaveManager.Instance.SaveFile(SaveManager.Instance.StageSavefp, saveData);
    }

    public void CreateSaveFile()
    {
        StageClearData data = new StageClearData();
        data.isUnlock[0] = true;
        data.isUnlock[1] = true;
        data.Gold = 0;

        for (int i = 2; i < data.isUnlock.Length; i++)
        {
            data.isUnlock[i] = false;
        }

        SaveManager.Instance.SaveFile<StageClearData>(SaveManager.Instance.StageSavefp, data);

        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);
    }

    public void isCanPlay()
    {
        if(play == null)
        {
            GameObject obj = GameObject.Find("Play_Button");
            play = obj.GetComponent<Button>();

            play.onClick.AddListener(LoadManager.Instance.GameStart);
        }

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
