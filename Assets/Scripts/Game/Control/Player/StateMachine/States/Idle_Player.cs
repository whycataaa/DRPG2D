using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MY_FrameWork;
public class Idle_Player : IState
{
    private FSM fsm;
    private BlackBoard_Player board;

    float stopTime;
    Vector3 vStart;
    float elapsedTime=0;


    public Idle_Player(FSM fsm)
    {
        this.fsm = fsm;
        board = fsm.blackBoard as BlackBoard_Player;
    }

    public void OnEnter()
    {

        vStart=board.PC.Rb.velocity;
        elapsedTime=0;
        stopTime=board.PC.Data_Player.StopTime;
    }

    public void OnExit()
    {
        board.PC.Rb.gravityScale=1;
    }

    public void OnUpdate()
    {
        if(board.PC.MoveInputX != 0)
        {
            fsm.ChangeState(StateType.Move);
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
        if(elapsedTime<stopTime)
        {
            elapsedTime+=Time.fixedDeltaTime;
            float t=elapsedTime/stopTime;
            float currentSpeed=Mathf.Lerp(vStart.x,0,t);
            board.PC.Rb.velocity=new Vector2(currentSpeed,board.PC.Rb.velocity.y);
        }
        else
        {
            board.PC.Rb.velocity=new Vector2(0,board.PC.Rb.velocity.y);
        }


    }

}
