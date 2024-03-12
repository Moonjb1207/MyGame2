using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{
    public TutoPage[] mytuto;
    int curtuto;

    private void Awake()
    {
        mytuto = GetComponentsInChildren<TutoPage>(true);
        curtuto = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        mytuto[curtuto].gameObject.SetActive(true);
    }

    public void NextTuto()
    {
        mytuto[curtuto].gameObject.SetActive(false);
        if(++curtuto >= mytuto.Length)
        {
            InGameManager.Instance.tutoClear = true;
            return;
        }
        mytuto[curtuto].gameObject.SetActive(true);
    }
}
