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
    public IGMGameoverState gameoverState;

    public BuildingManager buildManagner;
    public Button buildButton;

    public int stage;
    public int wave;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        mySpawner = GetComponentsInChildren<EnemyRespawn>();

        spawnerCount = 0;
        gameClear = false;
        tutoClear = false;

        buildingState = GetComponent<IGMBuildingState>();
        defenseState = GetComponent<IGMDefenseState>();
        finishState = GetComponent<IGMFinishState>();
        clearState = GetComponent<IGMClearState>();
        gameoverState = GetComponent<IGMGameoverState>();

        if (buildingState == null)
            buildingState = GetComponent<IGMBuildingState_T>();
        if (defenseState == null)
            defenseState = GetComponent<IGMDefenseState_T>();
        if (finishState == null)
            finishState = GetComponent<IGMFinishState_T>();
        if (clearState == null)
            clearState = GetComponent<IGMClearState_T>();

        if (defenseState == null)
            defenseState = GetComponent<IGMDefenseState_I>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //SoundManager.Instance.PlayPlayBGSound();

        stage = StageManager.Instance.stage;
        //error
        wave = StageManager.Instance.data.getStageStat_s(stage).wave;

        NextState(buildingState);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.Instance.IsLive)
        {
            NextState(gameoverState);
        }
        curIGState?.UpdateState();
    }

    public void NextState(IGMState state)
    {
        if (state == curIGState) return;

        curIGState = state;
        curIGState.EnterState();
    }
}
