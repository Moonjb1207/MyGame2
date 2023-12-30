using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBattle
{
    private static Player instance;
    public static Player Instance => instance;

    public float moveSpeed = 4.0f;
    public Rigidbody rg;
    public float curHP;

    public Transform bodyTr;
    public GameObject curWeapon;
    public Transform shootingPos;
    public LayerMask myEnemy;

    public int shootingCount;
    public float shootingDelay;
    public int curWeapNum;

    public Transform weaponContainer;

    Joystick joystick;

    Animator myAnim;

    private void Awake()
    {
        instance = this;

        rg = GetComponent<Rigidbody>();
        curHP = 10;

        joystick = FindObjectOfType<Joystick>();

        bodyTr = transform.Find("P_Jungle_Charc");
        shootingPos = curWeapon.transform.Find("shotPos");

        myAnim = bodyTr.GetComponent<Animator>();
        myAnim.SetFloat("AttackDelay", 1.5f);

        shootingCount = 3;
        shootingDelay = 0.2f;
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

            myAnim.SetBool("IsMoving", true);
        }
        else
        {
            myAnim.SetBool("IsMoving", false);
        }
    }

    public void MoveTo(Vector3 dir)
    {
        rg.velocity = dir * moveSpeed;
        bodyTr.forward = dir.normalized;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg;
    }

    public bool IsLive
    {
        get => true;
    }

    public void OnMeleeAttack()
    {
        if(myAnim.GetBool("IsAttacking"))
            return;

        myAnim.SetTrigger("M_Attacking");

        Vector3 attackPos = transform.position + new Vector3(0, 0.8f, 0.8f);

        Collider[] list = Physics.OverlapSphere(attackPos, 0.5f, myEnemy);
        if (list != null)
        {
            foreach(Collider col in list)
            {
                col.GetComponent<IBattle>().OnDamage(3);
            }
        }
    }

    public void OnRangedAttack()
    {
        if (myAnim.GetBool("IsAttacking"))
            return;

        myAnim.SetTrigger("R_Attacking");
        StartCoroutine(shootingBullets(shootingCount, shootingDelay));
    }

    public void Shooting()
    {
        Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, shootingPos.position, shootingPos.rotation);
    }

    IEnumerator shootingBullets(int count, float delay)
    {
        myAnim.SetBool("IsAttacking", true);
        while(count != 0)
        {
            count--;
            Shooting();
            yield return new WaitForSeconds(delay);
        }
        myAnim.SetBool("IsAttacking", false);
    }
    
    public void equipWeapon(int weapNum)
    {
        weaponContainer.GetChild(curWeapNum).gameObject.SetActive(false);
        weaponContainer.GetChild(weapNum).gameObject.SetActive(true);
    }
}
