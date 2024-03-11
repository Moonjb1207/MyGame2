using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{
    GameObject[] mytuto;
    int curtuto;

    private void Awake()
    {
        mytuto = GetComponentsInChildren<GameObject>(true);
        curtuto = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        mytuto[curtuto].SetActive(true);
    }

    public void NextTuto()
    {
        mytuto[curtuto].SetActive(false);
        if(++curtuto >= mytuto.Length)
        {
            InGameManager.Instance.tutoClear = true;
            return;
        }
        mytuto[curtuto].SetActive(true);
    }
}
