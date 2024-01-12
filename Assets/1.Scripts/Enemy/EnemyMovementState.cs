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
        //���� �������� ������
        if (distance <= enemy.data.attackRange)
        {
            myAnim.SetBool("IsMoving", false);
            agent.velocity = Vector3.zero;
            agent.isStopped = true;

            enemy.NextState(enemy.attackState);
            return;
        }
        else //���� �������� ��
        {
            if (agent.SetDestination(enemy.target.position))
            {
                myAnim.SetBool("IsMoving", true);
                agent.isStopped = false;
                //���ӵ��� �����Ͽ� ���� �̵� ó��
                agent.velocity = agent.desiredVelocity.normalized * agent.speed;
            }
        }
    }
}
