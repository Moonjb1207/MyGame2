using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementState : EnemyState
{
    public NavMeshAgent agent;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemy.data.moveSpeed;
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        curDelay += Time.deltaTime;

        if (enemy.target == null)
            return;

        Vector3 lookPoint = new Vector3(enemy.target.position.x, this.transform.position.y, enemy.target.position.z);
        transform.LookAt(lookPoint);

        float distance = (enemy.target.position - transform.position).magnitude;
        //공격 범위보다 가까우면
        if (distance <= enemy.data.attackRange)
        {
            myAnim.SetBool("IsMoving", false);
            agent.velocity = Vector3.zero;
            agent.isStopped = true;

            enemy.NextState(enemy.attackState);
            return;
        }
        else //공격 범위보다 멂
        {
            if (agent.SetDestination(enemy.target.position))
            {
                myAnim.SetBool("IsMoving", true);
                agent.isStopped = false;
                //가속도로 제외하여 유닛 이동 처리
                agent.velocity = agent.desiredVelocity.normalized * agent.speed;
            }
        }
    }
}
