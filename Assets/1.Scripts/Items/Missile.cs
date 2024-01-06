using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public LayerMask myEnemy;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;
    
    public IEnumerator movingMissile()
    {
        yield return null;
    }

    public void Create(Vector3 dir, float d, float lt, float ms)
    {
        transform.forward = dir;
        Damage = d;
        LifeTime = lt;
        moveSpeed = ms;
    }
}
