using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    public LayerMask myEnemy;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;

    public Transform mySpin;

    Vector3 direction = Vector3.forward;

    private void Start()
    {
        mySpin = transform.GetChild(0);
        StartCoroutine(movingWeapon());
    }

    IEnumerator movingWeapon()
    {
        transform.forward = direction;
        StartCoroutine(Spin());

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

                    EnemyWeaponPool.Instance.EnqueueWeapon(this);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                transform.Translate(transform.forward.normalized * delta, Space.World);
            }
            yield return null;
        }

        EnemyWeaponPool.Instance.EnqueueWeapon(this);
        gameObject.SetActive(false);
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
            float delta = 720.0f * Time.deltaTime;

            mySpin.Rotate(Vector3.up * delta, Space.World);

            yield return null;
        }
    }
}