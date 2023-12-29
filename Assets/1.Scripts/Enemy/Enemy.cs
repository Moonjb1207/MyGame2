using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBattle
{
    public float attackRange;
    public float moveSpeed;
    public float rotSpeed;
    public float attackDamage;

    public float curHP;

    protected EnemyMovement enemyMovement;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        curHP = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDamage(float dmg)
    {
        curHP -= dmg;
    }

    public bool IsLive
    {
        get => true;
    }

    public void OnAttack()
    {
        IBattle ib = Player.Instance.GetComponent<IBattle>();
        ib?.OnDamage(attackDamage);
        enemyMovement.myAnim.SetTrigger("Attacking");
    }
}
