using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] Menus;

    public GameObject SettingMenu;

    public Button ResetScene;


    public MenuName curMenu;

    private void Awake()
    {
        curMenu = MenuName.Main;
    }

    private void Start()
    {
        //SoundManager.Instance.PlayMainBGSound();
        ResetScene.onClick.AddListener(LoadManager.Instance.Change_to_ResetScene);
    }

    public void ChangeMenu(int menu)
    {
        for(int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
        }

        Menus[menu].SetActive(true);
        WarningManager.Instance.transform.SetParent(Menus[menu].transform.GetChild(0));
        InfoUI.Instance.transform.SetParent(Menus[menu].transform.GetChild(0));
    }

    public void OpenSettingMenu()
    {
        SettingMenu.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        SettingMenu.SetActive(false);
    }
}


public enum MenuName
{
    Main,
    Inventory,
    Store,
    StoreResult,
}