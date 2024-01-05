using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapBtn : MonoBehaviour
{
    public int idx;
    Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickedTapBtn); //�ڵ�� Button ������Ʈ�� �Լ� ��� 
    }

    void OnClickedTapBtn()
    {
        GetComponentInParent<TapContainer>().Select(idx);
    }
}