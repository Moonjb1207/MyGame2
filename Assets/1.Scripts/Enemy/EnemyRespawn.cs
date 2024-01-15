using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public int respawnCount;
    public int maxCount;
    public int curCount;
    public float respawnDelay;
    public float curDelay;

    // Start is called before the first frame update
    void Start()
    {
        int stage = StageManager.Instance.stage;

        respawnCount = StageManager.Instance.data.getStageStat(stage).respawnCount;
        maxCount = StageManager.Instance.data.getStageStat(stage).maxCount;
        respawnDelay = StageManager.Instance.data.getStageStat(stage).respawnDelay;

        curCount = 0;
        curDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curDelay += Time.deltaTime;
        if(curDelay >= respawnDelay && curCount < maxCount && respawnCount != 0)
        {
            curDelay = 0;
            curCount++;
            respawnCount--;

            int rnd = Random.Range(0, 10);
            if(rnd < 2)
            {
                Enemy myEnemy = EnemyPool.Instance.DequeueEnemy(EnemyQueueNum.Bomb, this);
                myEnemy.transform.position = transform.position;
                myEnemy.gameObject.SetActive(true);
            }
            else if(rnd < 5)
            {
                Enemy myEnemy = EnemyPool.Instance.DequeueEnemy(EnemyQueueNum.Range, this);
                myEnemy.transform.position = transform.position;
                myEnemy.gameObject.SetActive(true);
            }
            else if (rnd < 10)
            {
                Enemy myEnemy = EnemyPool.Instance.DequeueEnemy(EnemyQueueNum.Melee, this);
                myEnemy.transform.position = transform.position;
                myEnemy.gameObject.SetActive(true);
            }
        }
    }

    public void MyEnemyDead()
    {
        curCount--;
    }
}
