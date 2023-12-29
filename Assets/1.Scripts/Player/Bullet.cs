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
        moveSpeed = 3.0f;
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
        LifeTime -= Time.deltaTime;
        if(LifeTime < 0)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if((myEnemy & 1 << other.gameObject.layer) != 0)
        {
            other.GetComponent<IBattle>().OnDamage(Damage);
            Destroy(this);
        }
    }

    IEnumerator movingBullet()
    {
        while(true)
        {
            float delta = moveSpeed * Time.deltaTime;

            transform.Translate(transform.forward.normalized * delta, Space.World);

            yield return null;
        }
    }
}
