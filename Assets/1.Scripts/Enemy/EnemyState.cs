using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    public Enemy enemy;
    public virtual void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public abstract void EnterState();
    public abstract void UpdateState();
}
