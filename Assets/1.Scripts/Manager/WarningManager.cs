using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarningManager : MonoBehaviour
{
    private static WarningManager instance;
    public static WarningManager Instance => instance;

    public GameObject[] warnings;
    public UnityEvent myEvent;

    public bool needReset;

    private void Awake()
    {
        if (instance == null) instance = this;
        needReset = false;
    }

    public void ShowWarning(Transform parent, int index)
    {
        for(int i = 0; i < warnings.Length; i++)
        {
            warnings[i].gameObject.SetActive(false);
        }

        warnings[index].gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public void CloseOrCancel()
    {
        for (int i = 0; i < warnings.Length; i++)
        {
            warnings[i].gameObject.SetActive(false);
        }
    }

    public void CheckOrYes()
    {
        myEvent?.Invoke();
        myEvent.RemoveAllListeners();

        for (int i = 0; i < warnings.Length; i++)
        {
            warnings[i].gameObject.SetActive(false);
        }

        needReset = true;
    }
}
