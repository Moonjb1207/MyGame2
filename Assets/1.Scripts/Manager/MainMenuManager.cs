using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] Menus;


    public MenuName curMenu;

    private void Awake()
    {
        curMenu = MenuName.Main;
    }

    public void ChangeMenu(int menu)
    {
        for(int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
        }

        Menus[menu].SetActive(true);
    }
}


public enum MenuName
{
    Main,
    Inventory,
    Store,
    StoreResult,

}