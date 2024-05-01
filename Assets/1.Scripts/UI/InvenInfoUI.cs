using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenInfoUI : InfoUI
{
    private static InvenInfoUI instance;
    public static InvenInfoUI Instance => instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
