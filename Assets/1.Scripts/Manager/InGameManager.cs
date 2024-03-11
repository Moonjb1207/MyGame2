using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    private static InGameManager instance;
    public static InGameManager Instance => instance;

    public EnemyRespawn[] mySpawner;
    public int spawnerCount;

    public bool gameClear;
    public bool tutoClear;

    [SerializeField] IGMState curIGState;

    public IGMBuildingState buildingState;
    public IGMDefenseState defenseState;
    public IGMFinishState finishState;
    public IGMClearState clearState;

    public BuildingManager buildManagner;
    public Button buildButton;

    public int stage;
    public int wave;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        mySpawner = GetComponentsInChildren<EnemyRespawn>();

        wave = StageManager.Instance.data.stageStats[stage].wave;
        spawnerCount = 0;
        gameClear = false;
        tutoClear = false;

        buildingState = GetComponent<IGMBuildingState>();
        defenseState = GetComponent<IGMDefenseState>();
        finishState = GetComponent<IGMFinishState>();
        clearState = GetComponent<IGMClearState>();

        if (buildingState == null)
            GetComponent<IGMBuildingState_T>();
        if (defenseState == null)
            GetComponent<IGMDefenseState_T>();
        if (finishState == null)
            GetComponent<IGMFinishState_T>();
        if (clearState == null)
            GetComponent<IGMClearState_T>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayPlayBGSound();

        stage = StageManager.Instance.stage;
        NextState(buildingState);
    }

    // Update is called once per frame
    void Update()
    {
        curIGState?.UpdateState();
    }

    public void NextState(IGMState state)
    {
        if (state == curIGState) return;

        curIGState = state;
        curIGState.EnterState();
    }
}
