using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    public GameObject myBombEffect;

    public override void OnAttack()
    {
        curEnemyState.myAnim.SetTrigger("Attacking");
    }

    public void BombAttack()
    {
        Collider[] list = Physics.OverlapSphere(transform.position, 4.0f, myEnemy);
        if (list != null)
        {
            foreach (Collider col in list)
            {
                col.GetComponent<IBattle>().OnDamage(data.damage);
            }
        }

        GameObject temp = Instantiate(myBombEffect);
        temp.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if (transform.position == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4.0f);
    }
}