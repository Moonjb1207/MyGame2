using System;

[Serializable]
public class StageClearData
{
    //�������� ��, ������ ���� �迭�� �߰��Ҷ����� �÷������

    //Ʃ�丮�� 0, ���Ѹ�� Length - 1
    public bool[] isUnlock = new bool[4];
    public int Gold;
    //�������̸�_����
    public string[] buildingLevel = new string[4];
}
