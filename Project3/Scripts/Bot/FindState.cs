using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindState : IState<Bot>
{
    public float range = 10f;
    public void OnEnter(Bot t)
    {
        SeekTarget(t);
    }

    public void OnExcute(Bot t)
    {
        if (t.TargetEnemy != Vector3.zero)
        {
            t.ChangeState(new AttackState());
        }

        else if (t.IsDestination)
        {
            SeekTarget(t);
        }
        t.FindToEnemy();    
    }

    public void OnExit(Bot t)
    {

    }

    private void SeekTarget(Bot t)
    {
        Vector3 point;
        if (t.RandomPoint(t.transform.position, t.range, out point))
        {
            t.ChangeAnim(Constant.RunAnimName);
            Debug.DrawRay(point, Vector3.up, Color.yellow, 1.0f);
            t.SetDestination(point);
        }
    }
}
