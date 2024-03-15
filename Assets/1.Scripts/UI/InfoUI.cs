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
    public TMPro.TMP_Text costInfo;

    public Transform myMainImg;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        myMainImg = transform.GetChild(0);
    }

    public void setMyInfo(string n, string a, string e, string c)
    {
        nameInfo.text = n;
        abilityInfo.text = a;
        addExplainInfo.text = "추가 설명 : " + e;
        costInfo.text = c;

        myMainImg.gameObject.SetActive(true);
    }

    public void Close()
    {
        myMainImg.gameObject.SetActive(false);
    }
}
