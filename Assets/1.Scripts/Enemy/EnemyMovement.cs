using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NextAction();

public class EnemyMovement : MonoBehaviour
{
    Coroutine coFollow = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FollowTarget(Transform target, float moveSpeed, float rotSpeed, float attackRange, NextAction reached = null)
    {
        if (coFollow != null) StopCoroutine(coFollow);
        coFollow = StartCoroutine(FollowingTarget(target, moveSpeed, rotSpeed, attackRange, reached));
    }


    IEnumerator FollowingTarget(Transform target, float moveSpeed, float rotSpeed, float attackRange, NextAction reached = null)
    {
        while(target != null)
        {
            float rdelta = rotSpeed * Time.deltaTime;

            Vector3 dir = target.position - transform.position;

            dir.y = 0.0f;

            Vector3 rot =
                Vector3.RotateTowards(transform.forward, dir, rdelta * Mathf.Deg2Rad, 0.0f);
            transform.rotation = Quaternion.LookRotation(rot);

            if (dir.magnitude > attackRange)
            {
                float delta = moveSpeed * Time.deltaTime;

                if(delta > dir.magnitude - attackRange)
                {
                    delta = dir.magnitude - attackRange;
                }

                transform.Translate(dir.normalized * delta, Space.World);
            }
            else if (dir.magnitude <= attackRange)
            {
                reached?.Invoke();
                yield return new WaitForSeconds(3);
            }

            yield return null;
        }
    }

}
