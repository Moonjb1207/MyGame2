using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInfoUI : InfoUI
{
    private static StoreInfoUI instance;
    public static StoreInfoUI Instance => instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
