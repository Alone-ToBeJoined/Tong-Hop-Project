using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    private float currentTime;
    public void OnEnter(Bot t)
    {
        currentTime = 0f;
    }

    public void OnExcute(Bot t)
    {
        if (currentTime > 0f)
        {
            t.ChangeAnim(Constant.IdleAnimName);
        }
    }

    public void OnExit(Bot t)
    {

    }
}
