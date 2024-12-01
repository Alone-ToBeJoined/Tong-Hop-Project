using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BotState
{
    protected BotController bot;

    public BotState(BotController bot)
    {
        this.bot = bot; 
    }

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}