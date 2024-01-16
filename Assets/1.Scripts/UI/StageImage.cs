using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageImage : MonoBehaviour
{
    public Sprite[] stageIMG;
    public Image curIMG;


    private void Awake()
    {
        curIMG = GetComponent<Image>();
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
    }

    public void ChangeStageIMG()
    {
        curIMG.sprite = stageIMG[StageManager.Instance.stage];
    }
}
