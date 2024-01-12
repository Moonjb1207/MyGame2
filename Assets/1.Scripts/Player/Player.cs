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

    [SerializeField] EquipArmor[] armors;
    [SerializeField] EquipHelmet[] helmets;
    public EquipArmor curArmor;
    public EquipHelmet curHelmet;

    public GameObject InvenUI;


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

        if (InventoryManager.Instance == null)
        {
            EquipWeapon("colt");
            EquipArmor("none_armor");
            EquipHelmet("none_helmet");
        }
        else
        {
            EquipWeapon(InventoryManager.Instance.loadInven.myWeapon);
            EquipArmor(InventoryManager.Instance.loadInven.myArmor);
            EquipHelmet(InventoryManager.Instance.loadInven.myHelmet);
        }

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
            rg.velocity = Vector3.zero;
            myAnim.SetBool("IsMoving", false);
        }
    }

    public void MoveTo(Vector3 dir)
    {
        rg.velocity = dir * moveSpeed * curArmor.stat.equipmentSpeed * curHelmet.stat.equipmentSpeed;
        bodyTr.forward = dir.normalized;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg * curArmor.stat.Damage * curHelmet.stat.Damage;
    }

    public bool IsLive
    {
        get => true;
    }

    public void OnMeleeAttack()
    {
        if(myAnim.GetBool("IsAttacking"))
            return;

        if (curWeapon.stat.Damage == 0)
            myAnim.SetTrigger("MK_Attacking");
    }

    public void OnRangedAttack()
    {
        if (myAnim.GetBool("IsAttacking") || curWeapon.stat.Damage == 0 || curWeapon.IsAttacking)
            return;

        curWeapon.Attack();
        myAnim.SetTrigger("R_Attacking");
    }

    public void EquipWeapon(string weaponName)
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

    public void EquipArmor(string equipname)
    {
        if (curArmor != null)
            curArmor.gameObject.SetActive(false);

        for (int i = 0; i < armors.Length; i++)
        {
            if (armors[i].stat.equipName.Equals(equipname))
            {
                curArmor = armors[i];
                curArmor.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void EquipHelmet(string equipname)
    {
        if (curHelmet != null)
            curHelmet.gameObject.SetActive(false);

        for (int i = 0; i < helmets.Length; i++)
        {
            if (helmets[i].stat.equipName.Equals(equipname))
            {
                curHelmet = helmets[i];
                curHelmet.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void OpenInven()
    {
        InvenUI.SetActive(true);
    }

    public void CloseInven()
    {
        InvenUI.SetActive(false);
    }

    public void falseJoystick()
    {
        joystick.gameObject.SetActive(false);
    }

    public void trueJoystick()
    {
        joystick.gameObject.SetActive(true);
    }

}
