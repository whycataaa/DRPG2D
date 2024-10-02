using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    PlayerInput inputActions;

    #region 移动
    public Vector2 MovementValue{get;private set;}=Vector2.zero;
    public bool IsJump{get;private set;}
    
    #endregion
    

    #region 战斗
    public Vector2 HandMove{get;private set;}=Vector2.zero;
    #endregion
    void Awake()
    {
        if(inputActions==null)
        {
            inputActions=new();
        }

        inputActions.Enable();
        inputActions.GamePlay.Move.started+=OnMoveStarted;
        inputActions.GamePlay.Move.performed+=OnMovePerformed;
        inputActions.GamePlay.Move.canceled+=OnMoveCanceled;

        inputActions.GamePlay.Jump.started+=OnJumpStarted;
        inputActions.GamePlay.Jump.performed+=OnJumpPerformed;
        inputActions.GamePlay.Jump.canceled+=OnJumpCanceled;

        inputActions.GamePlay.HandMove.started+=OnHandMoveStarted;
        inputActions.GamePlay.HandMove.performed+=OnHandMovePerformed;
        inputActions.GamePlay.HandMove.canceled+=OnHandMoveCanceled;

    }





    #region Jump
    private void OnJumpStarted(InputAction.CallbackContext context)
    {
       IsJump=true;
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        IsJump=true;
    }
    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        IsJump=false;
    }
    #endregion

    #region Move
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
    #endregion

    #region Battle
    private void OnHandMoveStarted(InputAction.CallbackContext context)
    {
        HandMove=context.ReadValue<Vector2>();
    }
    private void OnHandMovePerformed(InputAction.CallbackContext context)
    {
        HandMove=context.ReadValue<Vector2>();
    }
    private void OnHandMoveCanceled(InputAction.CallbackContext context)
    {
        HandMove=context.ReadValue<Vector2>();
    }


    #endregion


}
