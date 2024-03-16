using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadManager : MonoBehaviour
{
    private static LoadManager instance;
    public static LoadManager Instance => instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void GameStart()
    {
        ChangeScene("PlayGame" + StageManager.Instance.stage);
    }

    public void Change_to_MainScene()
    {
        InventoryManager.Instance.EraseWeapons();
        Time.timeScale = 1.0f;
        ChangeScene("Main");
    }

    public void ResetDataYes()
    {
        File.Delete(SaveManager.Instance.StageSavefp);
        StageManager.Instance.CreateSaveFile();
        File.Delete(SettingManager.Instance.settingDataPath);
        SettingManager.Instance.CreateSaveFile();

        ChangeScene("Main");
    }
    public void ResetDataNo()
    {
        ChangeScene("Main");
    }

    public void Change_to_ResetScene()
    {
        ChangeScene("Reset");
    }
}
