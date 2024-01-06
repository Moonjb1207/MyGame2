using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInventory : MonoBehaviour
{
    public void GameStart()
    {
        InventoryManager.Instance.LoadScene();
        LoadManager.Instance.ChangeScene("PlayGame");
    }
}
