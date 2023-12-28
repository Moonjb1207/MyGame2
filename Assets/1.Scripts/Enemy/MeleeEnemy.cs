using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        FollowTarget(Target.transform, moveSpeed, rotSpeed, attackRange, OnAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
