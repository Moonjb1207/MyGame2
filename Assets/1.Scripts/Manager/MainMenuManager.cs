using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] Menus;

    public GameObject SettingMenu;


    public MenuName curMenu;

    private void Awake()
    {
        SoundManager.Instance.PlayMainBGSound();

        curMenu = MenuName.Main;
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