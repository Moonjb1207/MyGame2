using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    public static StageManager Instance => instance;

    public int stage;
    public Vector2 stageMinMax;

    public StageData data;

    private void Awake()
    {
        instance = this;

        stageMinMax = new Vector2(1, 1);

        stage = 1;
    }

    public void UpStage()
    {
        stage++;
        if(stage > stageMinMax.y)
        {
            stage = (int)stageMinMax.y;
        }
    }

    public void DownStage()
    {
        stage--;
        if (stage < stageMinMax.x)
        {
            stage = (int)stageMinMax.x;
        }
    }
}
