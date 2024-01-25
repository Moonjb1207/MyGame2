using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IGUIManager : MonoBehaviour
{
    private static IGUIManager instance;
    public static IGUIManager Instance => instance;

    public GameObject InvenUI;
    public GameObject BInvenUI;
    public GameObject ClearUI;
    public GameObject PauseUI;
    public TMPro.TMP_Text coin;
    public TMPro.TMP_Text myExp;
    public TMPro.TMP_Text needExp;
    public Button ClearButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coin.text = InventoryManager.Instance.myGold.ToString();
        myExp.text = Player.Instance.myExp.ToString();
        needExp.text = Player.Instance.lvexpData.LvExpDatas[Player.Instance.myLevel].needExp.ToString();

        ClearButton.onClick.AddListener(LoadManager.Instance.Change_to_MainScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInven()
    {
        InvenUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void CloseInven()
    {
        InvenUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OpenBInven()
    {
        BInvenUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void CloseBInven()
    {
        BInvenUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
