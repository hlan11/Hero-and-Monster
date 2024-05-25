using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CowController : EnemyController
{
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
    private void Update()
    {
        Invoke("AutoMove", 3f);
    }
}
