using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask myEnemy;
    public float LifeTime;
    public float moveSpeed;
    public float Damage;


    private void Awake()
    {
        LifeTime = 5.0f;
        moveSpeed = 20.0f;
        Damage = 2.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movingBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if((myEnemy & 1 << other.gameObject.layer) != 0)
        //{
        //    IBattle Ib = other.GetComponent<IBattle>();
        //    Ib?.OnDamage(Damage);

        //    Destroy(gameObject);
        //}
    }

    IEnumerator movingBullet()
    {
        while(LifeTime >= 0)
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

                    Destroy(gameObject);
                }
            }
            else
            {
                transform.Translate(transform.forward.normalized * delta, Space.World);
            }
            yield return null;
        }

        Destroy(gameObject);
    }
}
