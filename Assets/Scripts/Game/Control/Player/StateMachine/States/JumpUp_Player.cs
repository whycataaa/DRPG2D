using System.Collections;
using System.Collections.Generic;
using MY_FrameWork;
using UnityEngine;

public class JumpUp_Player : IState
{
    private FSM fsm;
    private BlackBoard_Player board;


    Vector2 currentVelocity;
    float elapsedTime;

    public JumpUp_Player(FSM fsm)
    {
        this.fsm = fsm;
        board = fsm.blackBoard as BlackBoard_Player;
    }
    public void OnEnter()
    {
        Debug.Log("JumpUp");

        board.PC.JumpTimes--;
        elapsedTime=0f;

        // currentVelocity = board.PC.Rb.velocity;
        board.PC.Rb.velocity=new Vector2(board.PC.Rb.velocity.x,board.PC.Data_Player.JumpUpMaxSpeed);
        //board.PC.Rb.AddForce(Vector2.up*board.PC.Data_Player.JumpUpMaxSpeed,ForceMode2D.Impulse);
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        //停止跳跃按键立即下落实现长短跳
        if(!board.PC.IsJump)
        {
            if(elapsedTime>board.PC.Data_Player.JumpToMinTime)
            {
                fsm.ChangeState(StateType.JumpDown);
            }
        }

        if(elapsedTime>board.PC.Data_Player.JumpToMinTime&&board.PC.Rb.velocity.y<=0)
        {
            fsm.ChangeState(StateType.JumpDown);
        }


    }
    public void OnFixedUpdate()
    {
         elapsedTime+= Time.fixedDeltaTime;
         float targetSpeed=board.PC.MoveInputX*board.PC.Data_Player.JumpMoveSpeed;
         board.PC.Move(currentVelocity.x,targetSpeed,board.PC.Data_Player.ToTargetTime,ref elapsedTime);

        // //y=-(Vm/t0)*t+Vm
        // board.PC.Rb.velocity=new Vector2(board.PC.Rb.velocity.x,
        //                                 (-board.PC.Data_Player.JumpUpMaxSpeed/board.PC.Data_Player.JumpToMaxTime)*elapsedTime+board.PC.Data_Player.JumpUpMaxSpeed);
        // //Debug.Log(board.PC.Rb.velocity);
    }

}
