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
    public GameObject curWeapon;
    public Transform shootingPos;
    public LayerMask myEnemy;

    public int shootingCount;
    public float shootingDelay;
    public int curWeapNum;

    public Transform weaponContainer;
    public WeaponData myWeapon;
    public float meleeDamage;

    public Transform armorContainer;
    public ArmorData myArmor;
    public float armorDamageReduced;
    public float armorSpeed;
    public int curArmorNum;

    public Transform helmetContainer;
    public HelmetData myHelmet;
    public float helmetDamageReduced;
    public float helmetSpeed;
    public int curHelmetNum;

    Joystick joystick;

    Animator myAnim;

    private void Awake()
    {
        instance = this;

        rg = GetComponent<Rigidbody>();
        curHP = 10;
        moveSpeed = 10;

        joystick = FindObjectOfType<Joystick>();

        bodyTr = transform.Find("P_Jungle_Charc");

        myAnim = bodyTr.GetComponent<Animator>();
        curWeapNum = -1;
        curArmorNum = -1;
        curHelmetNum = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        equipWeapon(0);
        equipArmor(0);
        equipHelmet(0);
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
        rg.velocity = dir * moveSpeed * armorSpeed * helmetSpeed;
        bodyTr.forward = dir.normalized;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg * armorDamageReduced * helmetDamageReduced;
    }

    public bool IsLive
    {
        get => true;
    }

    public void OnMeleeAttack()
    {
        if(myAnim.GetBool("IsAttacking"))
            return;

        if (curWeapNum > 1)
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
        if (myAnim.GetBool("IsAttacking") || curWeapNum <= 1)
            return;

        myAnim.SetTrigger("R_Attacking");
        StartCoroutine(shootingBullets(shootingCount, shootingDelay));
    }

    public void Shooting()
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, shootingPos.position, shootingPos.rotation);

        obj.GetComponent<Bullet>().moveSpeed = myWeapon.getWeaponStat(curWeapNum).moveSpeed;
        obj.GetComponent<Bullet>().LifeTime = myWeapon.getWeaponStat(curWeapNum).LifeTime;
        obj.GetComponent<Bullet>().Damage = myWeapon.getWeaponStat(curWeapNum).Damage;
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
        if (curWeapNum == weapNum) return;

        if (curWeapNum != -1)
        {
            weaponContainer.GetChild(curWeapNum).gameObject.SetActive(false);
        }
        curWeapNum = weapNum;
        weaponContainer.GetChild(curWeapNum).gameObject.SetActive(true);

        curWeapon = weaponContainer.GetChild(curWeapNum).gameObject;
        shootingPos = curWeapon.transform.Find("shotPos");

        shootingCount = myWeapon.getWeaponStat(curWeapNum).shootingCount;
        shootingDelay = myWeapon.getWeaponStat(curWeapNum).shootingDelay;
        myAnim.SetFloat("AttackDelay", myWeapon.getWeaponStat(curWeapNum).attackDelay);
        meleeDamage = myWeapon.getWeaponStat(curWeapNum).meleeDamage;
    }

    public void changeWeapon(int num)
    {
        equipWeapon(num);
    }

    public void equipArmor(int armorNum)
    {
        if (curArmorNum == armorNum) return;

        if (curArmorNum != -1)
        {
            armorContainer.GetChild(curArmorNum).gameObject.SetActive(false);
        }

        curArmorNum = armorNum;
        armorContainer.GetChild(curArmorNum).gameObject.SetActive(true);
        armorSpeed = myArmor.getArmorStat(curArmorNum).armorSpeed;
        armorDamageReduced = myArmor.getArmorStat(curArmorNum).Damage;
    }

    public void changeArmor(int num)
    {
        equipArmor(num);
    }

    public void equipHelmet(int helmetNum)
    {
        if (curHelmetNum == helmetNum) return;

        if (curHelmetNum != -1)
        {
            helmetContainer.GetChild(curHelmetNum).gameObject.SetActive(false);
        }

        curHelmetNum = helmetNum;
        helmetContainer.GetChild(curHelmetNum).gameObject.SetActive(true);
        helmetSpeed = myHelmet.getHelmetStat(curHelmetNum).helmetSpeed;
        helmetDamageReduced = myHelmet.getHelmetStat(curHelmetNum).Damage;
    }

    public void changeHelmet(int num)
    {
        equipHelmet(num);
    }
}
