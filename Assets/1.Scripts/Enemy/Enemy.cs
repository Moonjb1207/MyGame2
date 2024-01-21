using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IBattle
{
    public EnemyData data;

    public float curHP;
    public float curDelay;
    
    public Transform target;

    [SerializeField] protected EnemyState curEnemyState;
    public EnemyMovementState movementState;
    public EnemyAttackState attackState;
    public EnemyDeadState deadState;

    public LayerMask myEnemy;

    public EnemyQueueNum myNum;

    public EnemyRespawn mySpawn;


    public Image hpBar;

    private void Awake()
    {
        movementState = GetComponentInChildren<EnemyMovementState>();
        attackState = GetComponentInChildren<EnemyAttackState>();
        deadState = GetComponentInChildren<EnemyDeadState>();
    }

    private void OnEnable()
    {
        //GetComponent<Collider>().enabled = true;

        curHP = data.hp;
        hpBar.fillAmount = curHP / data.hp;
        
        target = Player.Instance?.transform;
        curDelay = 0;

        NextState(movementState);
    }

    public void NextState(EnemyState state)
    {
        curEnemyState = state;
        curEnemyState.EnterState();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = Player.Instance?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        curEnemyState?.UpdateState();
    }

    public void OnDamage(float dmg)
    {
        if(curHP > 0)
            curHP -= dmg;

        hpBar.fillAmount = curHP / data.hp;

        if (curHP <= 0)
        {
            curEnemyState.myAnim.SetTrigger("IsDying");
            NextState(deadState);
        }
    }

    public bool IsLive
    {
        get => true;
    }

    public virtual void OnAttack()
    {
        //IBattle ib = Player.Instance.GetComponent<IBattle>();
        //ib?.OnDamage(attackDamage);
        //enemyMovement.myAnim.SetTrigger("Attacking");
    }
    
    public void Dead()
    {
        curEnemyState.myAnim.SetBool("DyingEnd", true);
    }

    public void SaveMySpawn(EnemyRespawn myspawn)
    {
        mySpawn = myspawn;
    }

    public void AddExp(int exp)
    {

    }
    public void AddGold(int gold)
    {

    }
}
