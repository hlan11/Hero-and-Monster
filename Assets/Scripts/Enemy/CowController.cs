using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class CowController : EnemyController
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void AutoMove()
    {
        base.AutoMove();
        anim.SetTrigger("Walking");
    }
    protected override void autoMoveA()
    {
        base.autoMoveA();
        anim.SetTrigger("Walking");
    }
    protected override void autoMoveB()
    {
        base.autoMoveB();
        anim.SetTrigger("Walking");
    }
    protected override void Update()
    {
       
        Invoke("AutoMove", 3f);
    }
    public abstract override void TakeDamage(int damage);
}
