using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public Missile missilePrefab;
    public Missile myMissile;

    private void Awake()
    {
        if(myMissile == null)
        {
            myMissile = GetComponentInChildren<Missile>();
        }
    }

    public override void Attack()
    {
        if (myMissile == null)
        {
            CreateMissile();
            return;
        }

        myMissile.StartCoroutine(myMissile.movingMissile());
    }

    public void CreateMissile()
    {
        myMissile = Instantiate(missilePrefab);

        myMissile.transform.position = shootTr.position;
        myMissile.Create(transform.forward, stat.Damage, stat.LifeTime, stat.moveSpeed);
    }
}
