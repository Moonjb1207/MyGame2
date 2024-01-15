using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StageStat
{
    public int stage;
    public int respawnCount;
    public int maxCount;
    public int curCount;
    public float respawnDelay;
    public float curDelay;

    public StageStat(int s, int rc, int mc, int cc, float rd, float cd)
    {
        stage = s;
        respawnCount = rc;
        maxCount = mc;
        curCount = cc;
        respawnDelay = rd;
        curDelay = cd;
    }
}

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObject/StageData", order = int.MaxValue)]
public class StageData : ScriptableObject
{
    [SerializeField] StageStat[] stageStat;

    public StageStat[] stageStats
    {
        get => stageStat;
    }

    public StageStat getStageStat(int stage)
    {
        if (stage > stageStat.Length) return null;

        return stageStat[stage];
    }
}