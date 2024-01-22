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

    public int myLevel;
    public int myExp;

    public LvExpData lvexpData;

    Joystick joystick;

    Animator myAnim;

    private void Awake()
    {
        instance = this;

        rg = GetComponent<Rigidbody>();
        curHP = 10;
        moveSpeed = 7;
        myLevel = 1;
        myExp = 0;

        joystick = FindObjectOfType<Joystick>();

        bodyTr = transform.Find("P_Jungle_Charc");

        myAnim = bodyTr.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EquipItem(ItemType.weapon, InventoryManager.Instance.myWeapon);
        EquipItem(ItemType.armor, InventoryManager.Instance.myArmor);
        EquipItem(ItemType.helmet, InventoryManager.Instance.myHelmet);
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick == null) return;

        //if(Input.GetKey(KeyCode.W))
        //{
        //    //transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        //    MoveTo(Vector3.forward);
        //}

        if (!myAnim.GetBool("Dying"))
        {
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
    }

    public void MoveTo(Vector3 dir)
    {
        rg.velocity = dir * moveSpeed * curArmor.stat.equipmentSpeed;
        bodyTr.forward = dir.normalized;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg * curArmor.stat.Damage * curHelmet.stat.Damage;
        
        if(curHP <= 0 && !myAnim.GetBool("Dying"))
        {
            myAnim.SetTrigger("IsDying");
            rg.velocity = Vector3.zero;
        }
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
        {
            curWeapon.Attack();
            myAnim.SetTrigger("MK_Attacking");
        }
    }

    public void OnRangedAttack()
    {
        if (myAnim.GetBool("IsAttacking") || curWeapon.stat.Damage == 0 || curWeapon.IsAttacking)
            return;

        curWeapon.Attack();
        myAnim.SetTrigger("R_Attacking");
    }

    public void EquipItem(ItemType type, string equipName)
    {
        switch(type)
        {
            case ItemType.weapon:
                if (curWeapon != null)
                    curWeapon.gameObject.SetActive(false);

                for (int i = 0; i < weapons.Length; i++)
                {
                    if (weapons[i].stat.weaponName.Equals(equipName))
                    {
                        curWeapon = weapons[i];
                        curWeapon.gameObject.SetActive(true);
                        meleeDamage = curWeapon.stat.meleeDamage;
                        break;
                    }
                }
                break;
            case ItemType.armor:
                if (curArmor != null)
                    curArmor.gameObject.SetActive(false);

                for (int i = 0; i < armors.Length; i++)
                {
                    if (armors[i].stat.equipName.Equals(equipName))
                    {
                        curArmor = armors[i];
                        curArmor.gameObject.SetActive(true);
                        break;
                    }
                }
                break;
            case ItemType.helmet:
                if (curHelmet != null)
                    curHelmet.gameObject.SetActive(false);

                for (int i = 0; i < helmets.Length; i++)
                {
                    if (helmets[i].stat.equipName.Equals(equipName))
                    {
                        curHelmet = helmets[i];
                        curHelmet.gameObject.SetActive(true);
                        ChangeHelmet();
                        break;
                    }
                }
                break;
        }
    }

    public void ChangeHelmet()
    {
        if (CameraFollow.Instance == null) return;

        CameraFollow.Instance.transform.position = new Vector3(0, curHelmet.stat.equipmentSight.x, curHelmet.stat.equipmentSight.y);
    }

    public void falseJoystick()
    {
        joystick.gameObject.SetActive(false);
    }

    public void trueJoystick()
    {
        joystick.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        myAnim.speed = 0.0f;
        Time.timeScale = 0.0f;
    }
    
    public void AddExp(int exp)
    {
        myExp += exp;

        if (myExp >= lvexpData.LvExpDatas[myLevel].needExp)
        {
            if (myLevel == lvexpData.LvExpDatas.Length - 1)
            {
                return;
            }

            int remain = myExp - lvexpData.LvExpDatas[myLevel].needExp;
            myExp = 0;
            myExp += remain;

            myLevel++;
            LevelUp();
        }
    }

    public void AddGold(int gold)
    {
        InventoryManager.Instance.AddGold(gold);
    }

    public void LevelUp()
    {
        InventoryManager.Instance.AddItems(EquipmentManager.Instance.weaponData.weaponStats[myLevel].weaponName, ItemType.weapon);
    }
}
