using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadManager : MonoBehaviour
{
    private static LoadManager instance;
    public static LoadManager Instance => instance;

    public string curScene;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void ChangecurScene(string scene)
    {
        curScene = scene;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void LoadScene()
    {
        StartCoroutine(LoadingScene(curScene));
    }

    public void GameStart()
    {
        ChangecurScene("PlayGame" + StageManager.Instance.stage);
        SceneManager.LoadSceneAsync("Loading");
    }

    public void Change_to_MainScene()
    {
        InventoryManager.Instance.EraseWeapons();
        StageManager.Instance.stage = 0;
        Time.timeScale = 1.0f;
        ChangecurScene("Main");

        SceneManager.LoadSceneAsync("Loading");
    }

    public void ResetDataYes()
    {
        InventoryManager.Instance.mybuildingDic.Clear();

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


    public void FirstLoadScene()
    {
        curScene = "Main";
        StartCoroutine(LoadingScene(curScene));
    }

    IEnumerator LoadingScene(string scene)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);

        ao.allowSceneActivation = false;

        while(!ao.isDone)
        {
            if (ao.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2.0f);
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
