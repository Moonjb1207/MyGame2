using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscaner : Weapon
{
    public float atkRange;

    public LayerMask layerMask;

    public AudioClip shootSound;

    public override void Attack()
    {
        SoundManager.Instance.PlayEfSound(shootTr.position, shootSound);

        if (Physics.Raycast(shootTr.position, transform.forward, out RaycastHit hit, atkRange, layerMask))
        {
            hit.collider.GetComponent<IBattle>().OnDamage(stat.Damage);
        }

        RaycastHit[] hits = Physics.RaycastAll(shootTr.position, transform.forward, atkRange, layerMask);
        for(int i = 0; i < hits.Length; i++)
        {
            hits[i].collider.GetComponent<IBattle>().OnDamage(stat.Damage);
        }
    }

    private void OnDrawGizmos()
    {
        if (shootTr == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shootTr.position, atkRange);
    }
}
