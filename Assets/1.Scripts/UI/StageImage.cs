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

        UpStage.onClick.AddListener(StageManager.Instance.UpStage);
        UpStage.onClick.AddListener(ChangeStageIMG);
        DownStage.onClick.AddListener(StageManager.Instance.DownStage);
        DownStage.onClick.AddListener(ChangeStageIMG);

        StageManager.Instance.isCanPlay();
    }

    public void ChangeStageIMG()
    {
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
        stageText.text = "Stage  " + StageManager.Instance.stage.ToString();
    }
}
