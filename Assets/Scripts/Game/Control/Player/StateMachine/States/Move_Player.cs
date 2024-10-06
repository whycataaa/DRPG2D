using System.Collections;
using System.Collections.Generic;
using MY_FrameWork;
using UnityEngine;

public class Move_Player : IState
{
    private FSM fsm;
    private BlackBoard_Player board;

    //目标速度
    float targetSpeed;
    //达到目标速度的时间
    float reachTargetTime;

    float elapsedTime=0f;

    public Move_Player(FSM fsm)
    {
        this.fsm = fsm;
        board = fsm.blackBoard as BlackBoard_Player;
    }
    public void OnEnter()
    {
        Debug.Log("Move_Player OnEnter");
        board.PC.Rb.velocity=Vector2.zero;
        elapsedTime=0f;
        reachTargetTime=board.PC.Data_Player.ToTargetTime;
    }

    public void OnExit()
    {
        board.PC.Rb.gravityScale=1;
    }

    public void OnUpdate()
    {
        if(board.PC.MoveInputX==0)
        {
            fsm.ChangeState(StateType.Idle);
        }
        if(board.PC.IsJump)
        {
            fsm.ChangeState(StateType.JumpUp);
        }
        if(board.PC.IsLadder)
        {
            if(board.PC.MoveInputY!=0)
            {
                fsm.ChangeState(StateType.Ladder);
            }
        }
    }
    public void OnFixedUpdate()
    {
        targetSpeed=board.PC.MoveInputX*board.PC.Data_Player.MoveSpeed;
        if(elapsedTime<reachTargetTime)
        {
            elapsedTime+=Time.fixedDeltaTime;
            float t=elapsedTime/reachTargetTime;
            float currentSpeed=Mathf.Lerp(0,targetSpeed,t);

            board.PC.Rb.velocity=new Vector2(currentSpeed,board.PC.Rb.velocity.y);
        }
        else
        {
            board.PC.Rb.velocity=new Vector2(targetSpeed,board.PC.Rb.velocity.y);
        }


    }
}
