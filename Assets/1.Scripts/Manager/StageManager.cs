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
        CreateSaveFile();

        stage = 0;
    }
    
    public void StageClearSave()
    {
        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        saveData.Gold = InventoryManager.Instance.myGold;
        saveData.isUnlock[stage + 1] = true;

        SaveManager.Instance.SaveFile(SaveManager.Instance.StageSavefp, saveData);
    }

    public void TutorialStageClear()
    {
        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        saveData.Gold = InventoryManager.Instance.myGold;
        saveData.isUnlock[0] = false;

        SaveManager.Instance.SaveFile(SaveManager.Instance.StageSavefp, saveData);
    }

    public void CreateSaveFile()
    {
        saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);

        if (!SaveManager.Instance.IsExist)
        {
            StageClearData cdata = new StageClearData();

            cdata.isUnlock[0] = true;
            cdata.isUnlock[1] = true;
            for (int i = 2; i < cdata.isUnlock.Length; i++)
            {
                cdata.isUnlock[i] = false;
            }

            cdata.Gold = 0;

            cdata.buildingLevel[0] = EquipmentManager.Instance.buildingData.buildingStats[0].buildingName + "_" + 1;
            for (int i = 1; i < cdata.buildingLevel.Length; i++)
            {
                cdata.buildingLevel[i] = EquipmentManager.Instance.buildingData.buildingStats[i].buildingName + "_" + 0;
            }

            SaveManager.Instance.SaveFile<StageClearData>(SaveManager.Instance.StageSavefp, cdata);

            saveData = SaveManager.Instance.LoadFile<StageClearData>(SaveManager.Instance.StageSavefp);
        }

        InventoryManager.Instance.myGold = saveData.Gold;

        string[] buildingInfo = saveData.buildingLevel[0].Split('_');

        InventoryManager.Instance.mybuildingDic.Add(buildingInfo[0], System.Int32.Parse(buildingInfo[1]));
        InventoryManager.Instance.myBuilding = buildingInfo[0];

        for (int i = 1; i < saveData.buildingLevel.Length; i++)
        {
            buildingInfo = saveData.buildingLevel[i].Split('_');

            InventoryManager.Instance.mybuildingDic.Add(buildingInfo[0], System.Int32.Parse(buildingInfo[1]));
        }

        stageMinMax = new Vector2(0, data.stageStats.Length - 1);

        if(stage >= stageMinMax.y)
        {
            stage = 0;
        }
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
    
    public bool isCanPlay_I()
    {
        if (saveData.isUnlock[0])
        {
            return false;
        }
        else
        {
            return true;
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
