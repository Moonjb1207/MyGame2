using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageImage : MonoBehaviour
{
    public Sprite[] stageIMG;
    public Image curIMG;
    public TMPro.TMP_Text stageText;

    public Button UpStage;
    public Button DownStage;


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
}
