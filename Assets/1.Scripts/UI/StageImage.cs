using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageImage : MonoBehaviour
{
    public Sprite[] stageIMG;
    public Image curIMG;
    public TMPro.TMP_Text stageText;


    private void Awake()
    {
        curIMG = GetComponent<Image>();
    }

    private void Start()
    {
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
        stageText.text = "Stage  " + StageManager.Instance.stage.ToString();
    }

    public void ChangeStageIMG()
    {
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
        stageText.text = "Stage  " + StageManager.Instance.stage.ToString();
    }

    public void GameStart()
    {
        LoadManager.Instance.ChangeScene("PlayGame" + StageManager.Instance.stage);
    }
}
