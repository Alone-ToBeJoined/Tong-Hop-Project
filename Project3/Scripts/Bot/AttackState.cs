using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Constant.AttackAnimName);
    }

    public void OnExcute(Bot t)
    {
        if (t.TargetEnemy == Vector3.zero)
        {
            t.ChangeState(new FindState());
        }
        else if (t.currentTime <= 0)
        {
            t.MoveStop();
            t.OnAttack();
        }
    }

    public void OnExit(Bot t)
    {

    }
}
