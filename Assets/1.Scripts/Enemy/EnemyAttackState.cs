using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{

    public override void EnterState()
    {

    }

    //���� �ڵ��� ���� - ���� ���� �ӵ��� ���� ó���� ������� �ʾҽ��ϴ�.
    public override void UpdateState()
    {
        enemy.OnAttack();
        enemy.NextState(enemy.movementState);
    }
}
