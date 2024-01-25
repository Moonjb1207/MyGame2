using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Change_to_MainScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("Main");
    }
}
