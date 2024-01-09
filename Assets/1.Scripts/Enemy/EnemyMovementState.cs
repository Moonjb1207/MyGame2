using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementState : EnemyState
{
    public NavMeshAgent agent;
    public Transform bodyTr;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemy.data.moveSpeed;
        bodyTr = transform.Find("Body");
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        if (enemy.target == null)
            return;

        Vector3 lookPoint = new Vector3(enemy.target.position.x, this.transform.position.y, enemy.target.position.z);
        transform.LookAt(lookPoint);

        float distance = (enemy.target.position - transform.position).magnitude;
        //���� �������� ������
        if (distance <= enemy.data.attackRange)
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;

            enemy.NextState(enemy.attackState);
            return;
        }
        else //���� �������� ��
        {
            if (agent.SetDestination(enemy.target.position))
            {
                agent.isStopped = false;
                //���ӵ��� �����Ͽ� ���� �̵� ó��
                agent.velocity = agent.desiredVelocity.normalized * agent.speed;
            }
        }
    }

}
