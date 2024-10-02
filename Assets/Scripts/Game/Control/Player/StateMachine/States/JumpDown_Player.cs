using System.Collections;
using System.Collections.Generic;
using MY_FSM;
using UnityEngine;

public class JumpDown_Player : IState
{
    private FSM fsm;
    private BlackBoard_Player board;

    float elapsedTime;
    Vector2 currentVelocity;
    float EnterVelocityY;
    public JumpDown_Player(FSM fsm)
    {
        this.fsm = fsm;
        board = fsm.blackBoard as BlackBoard_Player;
    }

    public void OnEnter()
    {
        // Debug.Log("JumpDown");
        elapsedTime = 0;
        // EnterVelocityY=board.PC.Rb.velocity.y;
        currentVelocity = board.PC.Rb.velocity;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if (board.PC.IsGrounded)
        {
            fsm.ChangeState(StateType.Idle);
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
         elapsedTime += Time.fixedDeltaTime;

         float targetSpeed=board.PC.MoveInputX*board.PC.Data_Player.JumpMoveSpeed;
         board.PC.Move(currentVelocity.x,targetSpeed,board.PC.Data_Player.ToTargetTime,ref elapsedTime);

        // if(elapsedTime <= board.PC.Data_Player.JumpDownToMaxTime)
        // {
        //      board.PC.Rb.velocity=new Vector2(board.PC.Rb.velocity.x,
        //                                     -(((board.PC.Data_Player.JumpDownMaxSpeed-EnterVelocityY)/board.PC.Data_Player.JumpDownToMaxTime)*elapsedTime+EnterVelocityY));
        // }
        // else
        // {
        //     board.PC.Rb.velocity=new Vector2(board.PC.Rb.velocity.x,-board.PC.Data_Player.JumpDownMaxSpeed);
        // }
        
        // Debug.Log(board.PC.Rb.velocity);
    }



}
