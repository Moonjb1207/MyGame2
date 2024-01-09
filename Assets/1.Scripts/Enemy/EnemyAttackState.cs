using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{

    public override void EnterState()
    {

    }

    //현재 코드의 문제 - 적의 공격 속도에 따른 처리가 고려되지 않았습니다.
    public override void UpdateState()
    {
        enemy.OnAttack();
        enemy.NextState(enemy.movementState);
    }
}
