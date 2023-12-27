using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyMovement, IBattle
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDamage(float dmg)
    {

    }

    public bool IsLive
    {
        get => true;
    }
}
