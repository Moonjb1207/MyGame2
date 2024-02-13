using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    private static InfoUI instance;
    public static InfoUI Instance => instance;

    public TMPro.TMP_Text nameInfo;
    public TMPro.TMP_Text abilityInfo;
    public TMPro.TMP_Text addExplainInfo;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void setMyInfo(string n, string a, string e, string t, Transform parent)
    {
        transform.SetParent(parent);

        nameInfo.text = n;
        abilityInfo.text = t + " : " + a;
        addExplainInfo.text = "추가 설명 : " + e;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
