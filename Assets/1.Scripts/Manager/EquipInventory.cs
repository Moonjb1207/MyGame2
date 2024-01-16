using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInventory : MonoBehaviour
{
    public void GameStart()
    {
        LoadManager.Instance.ChangeScene("PlayGame" + StageManager.Instance.stage);
    }
}
