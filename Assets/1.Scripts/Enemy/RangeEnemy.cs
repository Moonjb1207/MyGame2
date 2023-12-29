using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement.FollowTarget(Player.Instance.transform, moveSpeed, rotSpeed, attackRange, OnAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
