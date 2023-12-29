using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBattle
{
    private static Player instance;
    public static Player Instance => instance;

    public float moveSpeed = 2.0f;
    public Rigidbody rg;
    public float curHP;

    public Transform bodyTr;

    Joystick joystick;

    private void Awake()
    {
        instance = this;

        rg = GetComponent<Rigidbody>();
        curHP = 10;

        joystick = FindObjectOfType<Joystick>();

        bodyTr = transform.Find("Body");

        Debug.Log(joystick.Direction);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.W))
        //{
        //    //transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        //    MoveTo(Vector3.forward);
        //}

        if (joystick.Direction.magnitude > 0)
        {
            Vector3 dir = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);

            MoveTo(dir);
        }
    }

    public void MoveTo(Vector3 dir)
    {
        rg.velocity = dir * moveSpeed;
        bodyTr.forward = dir;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg;
    }

    public bool IsLive
    {
        get => true;
    }
}
