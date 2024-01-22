using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    float eraseTime = 3.0f;

    public override void EnterState()
    {
        //GetComponent<Collider>().enabled = false;
        DropCoin();
        DropExp();
    }

    public override void UpdateState()
    {
        //if (transform.position.y > -1.0f && myAnim.GetBool("DyingEnd"))
        //{
        //    float delta = 1f * Time.deltaTime;
        //    transform.Translate(Vector3.down * delta);
        //}
        //else if(transform.position.y <= -1.0f)
        //{
        //    gameObject.SetActive(false);
        //    EnemyPool.Instance.EnqueueEnemy(enemy, enemy.myNum);
        //}

        if(myAnim.GetBool("DyingEnd"))
        {
            eraseTime -= Time.deltaTime;
        }
        if(eraseTime < 0)
        {
            myAnim.SetBool("DyingEnd", false);
            enemy.mySpawn.MyEnemyDead();
            gameObject.SetActive(false);
            EnemyPool.Instance.EnqueueEnemy(enemy, enemy.myNum);
        }
    }

    public void DropCoin()
    {
        int gold = Random.Range(10, 50);

        CoinPool.Instance.DequeueCoin(gold, enemy.transform);
    }

    public void DropExp()
    {
        int exp = Random.Range(1, 5);

        ExpBallPool.Instance.DequeueBall(exp, enemy.transform);
    }
}