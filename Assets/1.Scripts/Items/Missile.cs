using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public LayerMask myEnemy;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;

    public GameObject expEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == myEnemy)
        {
            Collider[] list = Physics.OverlapSphere(transform.position + new Vector3(0, 0, 0.5f), 5.0f, myEnemy);
            if (list != null)
            {
                foreach (Collider col in list)
                {
                    col.GetComponent<IBattle>().OnDamage(Damage);
                }
            }
            MissilePool.Instance.EnqueueMissile(this);
            gameObject.SetActive(false);
        }
    }

    IEnumerator movingMissile()
    {
        while (LifeTime >= 0)
        {
            LifeTime -= Time.deltaTime;

            float delta = moveSpeed * Time.deltaTime;
            transform.Translate(transform.forward.normalized * delta, Space.World);

            yield return null;
        }

        Collider[] list = Physics.OverlapSphere(transform.position + new Vector3(0, 0, 0.5f), 5.0f, myEnemy);
        if (list != null)
        {
            foreach (Collider col in list)
            {
                col.GetComponent<IBattle>().OnDamage(Damage);
            }
        }
        MissilePool.Instance.EnqueueMissile(this);
        gameObject.SetActive(false);
    }

    public void Shooting()
    {
        StartCoroutine(movingMissile());
    }

    public void Create(Vector3 dir, float d, float lt, float ms)
    {
        transform.forward = dir;
        Damage = d;
        LifeTime = lt;
        moveSpeed = ms;
    }
}
