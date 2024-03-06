using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SettingManager : MonoBehaviour
{
    public SettingData mySettingData = new SettingData();

    public float MSSound;
    public float BGSound;
    public float EFSound;
    
    private static SettingManager instance;
    public static SettingManager Instance => instance;

    [SerializeField] string settingDataPath = "";

    float defaultSound = 1.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        settingDataPath = Application.dataPath + @"gameSettingData.data";

        if(!File.Exists(settingDataPath))
        {
            mySettingData.msSound = defaultSound;
            mySettingData.bgSound = defaultSound;
            mySettingData.efSound = defaultSound;

            string data = JsonUtility.ToJson(mySettingData);

            File.Create(settingDataPath).Close();
            File.WriteAllText(settingDataPath, data);
        }
        else
        {
            SettingLoad(settingDataPath);
        }
    }
    public void SettingLoad(string path)
    {
        string data = File.ReadAllText(path);

        mySettingData = JsonUtility.FromJson<SettingData>(data);

        MSSound = mySettingData.msSound;
        BGSound = mySettingData.bgSound;
        EFSound = mySettingData.efSound;
    }

    public void SettingSave(string path)
    {
        mySettingData.msSound = MSSound;
        mySettingData.bgSound = BGSound;
        mySettingData.efSound = EFSound;

        string data = JsonUtility.ToJson(mySettingData);

        File.WriteAllText(path, data);
    }
}
