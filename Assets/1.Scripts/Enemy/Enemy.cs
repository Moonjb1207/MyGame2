using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBattle
{
    public EnemyData data;

    public float attackRange;
    public float moveSpeed;
    public float rotSpeed;
    public float attackDamage;

    public float curHP;
    
    public Transform target;

    [SerializeField] EnemyState curEnemyState;
    public EnemyMovementState movementState;
    public EnemyAttackState attackState;

    private void Awake()
    {
        movementState = GetComponentInChildren<EnemyMovementState>();
        attackState = GetComponentInChildren<EnemyAttackState>();
    }

    private void OnEnable()
    {
        curHP = data.hp;
        target = Player.Instance?.transform;

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
        curHP -= dmg;
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
}
