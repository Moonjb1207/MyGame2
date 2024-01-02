using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public Transform attackPos;
    public LayerMask myEnemy;

    public override void Attack()
    {
        Collider[] list = Physics.OverlapSphere(attackPos.position + new Vector3(0, 0, 0.5f), stat.LifeTime, myEnemy);
        if (list != null)
        {
            foreach (Collider col in list)
            {
                col.GetComponent<IBattle>().OnDamage(stat.meleeDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPos == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position + new Vector3(0, 0, 0.5f), stat.LifeTime);
    }
}
