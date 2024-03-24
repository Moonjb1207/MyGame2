using System;

[Serializable]
public class StageClearData
{
    //스테이지 락, 구조물 저장 배열은 추가할때마다 늘려줘야함

    //튜토리얼 0, 무한모드 Length - 1
    public bool[] isUnlock = new bool[4];
    public int Gold;
    //구조물이름_레벨
    public string[] buildingLevel = new string[4];
}
