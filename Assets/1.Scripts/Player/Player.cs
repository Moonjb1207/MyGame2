using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBattle
{
    private static Player instance;
    public static Player Instance => instance;

    public float moveSpeed;
    public Rigidbody rg;
    public float curHP;

    public Transform bodyTr;
    public LayerMask myEnemy;

    [SerializeField] Weapon[] weapons;
    public Weapon curWeapon;

    public float meleeDamage;

    [SerializeField] Equipment[] equips;
    public EquipArmor curArmor;
    public EquipHelmet curHelmet;


    Joystick joystick;

    Animator myAnim;

    private void Awake()
    {
        instance = this;

        rg = GetComponent<Rigidbody>();
        curHP = 10;
        moveSpeed = 7;

        joystick = FindObjectOfType<Joystick>();

        bodyTr = transform.Find("P_Jungle_Charc");

        myAnim = bodyTr.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EquipWeapon(WeaponName.colt);
        EquipArmor(EquipName.none_armor);
        EquipHelmet(EquipName.none_helmet);
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
        rg.velocity = dir * moveSpeed * curHelmet.stat.equipmentSpeed * curHelmet.stat.equipmentSpeed;
        bodyTr.forward = dir.normalized;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg * curHelmet.stat.Damage * curHelmet.stat.Damage;
    }

    public bool IsLive
    {
        get => true;
    }

    public void OnMeleeAttack()
    {
        if(myAnim.GetBool("IsAttacking"))
            return;

        if ((int)curWeapon.stat.weaponName > 1)
            myAnim.SetTrigger("M_Attacking");
        else
            myAnim.SetTrigger("MK_Attacking");

        Vector3 attackPos = transform.position + new Vector3(0, 0.8f, 0.8f);

        Collider[] list = Physics.OverlapSphere(attackPos, 0.5f, myEnemy);
        if (list != null)
        {
            foreach(Collider col in list)
            {
                col.GetComponent<IBattle>().OnDamage(meleeDamage);
            }
        }
    }

    public void OnRangedAttack()
    {
        if (myAnim.GetBool("IsAttacking") || (int)curWeapon.stat.weaponName <= 1 || curWeapon.IsAttacking)
            return;

        curWeapon.Attack();
        myAnim.SetTrigger("R_Attacking");
    }

    public void EquipWeapon(WeaponName weaponName)
    {
        if (curWeapon != null)
            curWeapon.gameObject.SetActive(false);

        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i].stat.weaponName.Equals(weaponName))
            {
                curWeapon = weapons[i];
                curWeapon.gameObject.SetActive(true);
                meleeDamage = curWeapon.stat.meleeDamage;
                break;
            }
        }
    }

    public void EquipArmor(EquipName equipname)
    {
        if (curArmor != null)
            curArmor.gameObject.SetActive(false);

        for (int i = 0; i < equips.Length; i++)
        {
            if (equips[i].stat.equipName.Equals(equipname))
            {
                curArmor = (EquipArmor)equips[i];
                curArmor.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void EquipHelmet(EquipName equipname)
    {
        if (curHelmet != null)
            curHelmet.gameObject.SetActive(false);

        for (int i = 0; i < equips.Length; i++)
        {
            if (equips[i].stat.equipName.Equals(equipname))
            {
                curHelmet = (EquipHelmet)equips[i];
                curHelmet.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void changeWeapon(int i)
    {
        EquipWeapon((WeaponName)i);
    }

    public void changeArmor(int i)
    {
        EquipArmor((EquipName)i);
    }

    public void changeHelmet(int i)
    {
        EquipHelmet((EquipName)(i + (int)EquipName.none_helmet));
    }
}
