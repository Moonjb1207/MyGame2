using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
    public Button Yes;
    public Button No;

    // Start is called before the first frame update
    void Start()
    {
        Yes.onClick.AddListener(LoadManager.Instance.ResetDataYes);
        No.onClick.AddListener(LoadManager.Instance.ResetDataNo);
    }
}
