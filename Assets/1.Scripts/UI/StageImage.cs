using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageImage : MonoBehaviour
{
    public Image[] stageIMG;
    public Image curIMG;


    private void Awake()
    {
        curIMG = GetComponent<Image>();
        curIMG = stageIMG[StageManager.Instance.stage];
    }

    public void ChangeStageIMG()
    {
        curIMG = stageIMG[StageManager.Instance.stage];
    }
}
