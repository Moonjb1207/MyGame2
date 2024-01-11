using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    public LayerMask myEnemy;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;

    Vector3 direction = Vector3.forward;

    private void Start()
    {
        StartCoroutine(movingWeapon());
    }

    IEnumerator movingWeapon()
    {
        transform.forward = direction;

        while (LifeTime >= 0)
        {
            LifeTime -= Time.deltaTime;

            Ray ray = new Ray();
            ray.origin = transform.position;
            ray.direction = transform.forward;

            float delta = moveSpeed * Time.deltaTime;

            if (Physics.Raycast(ray, out RaycastHit hit, delta, myEnemy))
            {
                if ((myEnemy & 1 << hit.transform.gameObject.layer) != 0)
                {
                    IBattle ib = hit.transform.GetComponent<IBattle>();
                    ib?.OnDamage(Damage);

                    //BulletPool.Instance.EnqueueBullet(this);
                    Destroy(gameObject);
                }
            }
            else
            {
                transform.Translate(transform.forward.normalized * delta, Space.World);
            }
            yield return null;
        }

        //BulletPool.Instance.EnqueueBullet(this);
        Destroy(gameObject);
    }

    public void Shoot(Vector3 dir, float d, float lt, float ms)
    {
        direction = dir;
        Damage = d;
        LifeTime = lt;
        moveSpeed = ms;
    }

    IEnumerator Spin()
    {
        while(true)
        {
            yield return null;
        }
    }
}
