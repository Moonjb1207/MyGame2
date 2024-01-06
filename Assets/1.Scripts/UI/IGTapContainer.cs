using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGTapContainer : MonoBehaviour
{
    public IGTapBtn[] tapBtns;
    public IGTapPanel[] tapPanels;

    private void Awake()
    {
        tapBtns = GetComponentsInChildren<IGTapBtn>(); //������ Ȱ��ȭ�� ������Ʈ�� ��� TapBtn ������Ʈ ã�� �迭�� ��ȯ
        tapPanels = GetComponentsInChildren<IGTapPanel>(true);//������ ��� TapPanel ������Ʈ �迭 ã�� - ��Ȱ��ȭ�� ������Ʈ ����
        curIdx = 0;

        for (int i = 0; i < tapBtns.Length; i++)
        {
            tapBtns[i].idx = i;
        }
    }

    public int curIdx //ĸ��ȭ - ���� ��ü���� ���� ���������� �ܺ� ��ü���� ���� �Ұ�
    {
        private set;
        get;
    }

    private void Start()
    {
        Select(curIdx);
    }

    public void Select(int idx)
    {
        tapPanels[curIdx].gameObject.SetActive(false);
        curIdx = idx; //���õ� �ε���
                      //�����غ��� - tapPanels �迭�� �ε��� curIdx�� Ȱ��ȭ�ϱ�
        tapPanels[curIdx].gameObject.SetActive(true);

        if (!tapPanels[curIdx].isUpdated)
        {
            tapPanels[curIdx].LoadEquipment(idx);
        }
    }
}
