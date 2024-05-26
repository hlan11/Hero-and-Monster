using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CowController : EnemyController
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
        base.Update();
        Invoke("AutoMove", 3f);
    }
}
