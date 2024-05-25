using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : EnemyController
{
    [SerializeField] private int damage;
    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        Attack();
    }
    void Attack()
    {
        if (CheckPlayer())
        {
            Debug.Log("--------------------------detected player-------------------");
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
}
