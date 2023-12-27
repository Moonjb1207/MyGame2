using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBattle
{
    public float moveSpeed = 2.0f;
    public Rigidbody rg;
    public int curHP;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        curHP = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
            MoveTo(Vector3.forward);
        }
    }

    public void MoveTo(Vector3 dir)
    {
        rg.velocity = dir * moveSpeed;
    }

    public void OnDamage(float dmg)
    {

    }

    public bool IsLive
    {
        get => true;
    }
}
