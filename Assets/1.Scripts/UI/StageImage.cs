using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageImage : MonoBehaviour
{
    public GameObject infiniteMode;

    public Sprite[] stageIMG;
    public Image curIMG;
    public TMPro.TMP_Text stageText;

    public Button UpStage;
    public Button DownStage;
    public Button yesInfinite;


    private void Awake()
    {
        curIMG = GetComponent<Image>();
    }

    private void Start()
    {
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
        stageText.text = "Stage  " + StageManager.Instance.stage.ToString();

        StageManager.Instance.isCanPlay();
    }

    public void ChangeStageIMG()
    {
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
        stageText.text = "Stage  " + StageManager.Instance.stage.ToString();
    }

    public void UpStageButton()
    {
        StageManager.Instance.UpStage();
        ChangeStageIMG();
    }

    public void DownStageButton()
    {
        StageManager.Instance.DownStage();
        ChangeStageIMG();
    }

    public void OpenInfiniteStage()
    {
        infiniteMode.SetActive(true);

        if (StageManager.Instance.isCanPlay_I())
        {
            yesInfinite.interactable = true;
        }
        else
        {
            yesInfinite.interactable = false;
        }
    }

    public void CloseInfiniteStage()
    {
        infiniteMode.SetActive(false);
    }

    public void PlayInfiniteStage()
    {
        StageManager.Instance.stage = 99;

        LoadManager.Instance.GameStart();
    }
}
