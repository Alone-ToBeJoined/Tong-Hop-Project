using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public BotState currentState;

    public IdleState idleState;
    public CollectBrickState collectBrickState;
    public BuildStairState buildStairState;

    private void Start()
    {
        //khoi tao trang thai
        idleState = new IdleState(this);
        collectBrickState = new CollectBrickState(this);
        buildStairState = new BuildStairState(this);

        currentState = idleState;
        currentState.EnterState();
    }

    private void Update()
    {
        //cap nhat trang thai hien tai
        currentState.UpdateState(); 
    }

    public void SwitchState(BotState newState)
    {
        currentState.ExitState(); //thoat khoi trang thai hien tai
        currentState = newState; //chuyen sang trang thai moi
        currentState.EnterState(); //kich hoat trang thai moi
    }
}
