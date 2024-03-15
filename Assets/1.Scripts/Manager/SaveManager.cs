using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public static SaveManager Instance => instance;
    public bool IsExist;

    public string StageSavefp = "";

    private void Awake()
    {
        if (instance == null)
            instance = this;

        StageSavefp = Application.dataPath + @"\StageClear.data";
    }

    public void SaveFile<T>(string fpath, T data)
    {
        if (!File.Exists(fpath))
        {
            File.Create(fpath).Close();
        }

        string ToJsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(fpath, ToJsonData);

    }

    public T LoadFile<T>(string fpath)
    {
        T data = default;

        if (File.Exists(fpath))
        {
            IsExist = true;
            string FromJsonData = File.ReadAllText(fpath);
            data = JsonUtility.FromJson<T>(FromJsonData);
        }
        else
        {
            Debug.Log(fpath + "파일이 존재하지 않습니다.");
            IsExist = false;
        }

        return data;
    }
}
