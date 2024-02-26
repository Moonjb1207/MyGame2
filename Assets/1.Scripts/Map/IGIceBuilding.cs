using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGIceBuilding : IGBuilding
{
    float curDelay = 0.0f;
    public LayerMask myEnemy;

    private void Start()
    {
        curDelay = Delay;
    }

    private void Update()
    {
        curDelay -= Time.deltaTime;

        if(curDelay < 0.0f)
        {
            Collider[] list = Physics.OverlapSphere(transform.position, 5.0f, myEnemy);
            if(list != null)
            {
                foreach(Collider col in list)
                {
                    Enemy enemy = col.GetComponent<Enemy>();
                    enemy.AddDeBuff(new DeBuff(DeBuffType.Slow, KeepTime, Value, DamageTime));
                }
            }
        }
    }
}
