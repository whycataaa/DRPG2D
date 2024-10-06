using System;
using UnityEngine;
using MY_FrameWork;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerController : MonoBehaviour
{
    PlayerInputHandler inputHandler;
    CameraFollowObject cameraFollowObject;
    GroundDetect groundDetect;
    LadderDetect ladderDetect;
    GameObject playerGO;
    public Animator BodyAnimator;

    #region Movement
    [DisplayOnly][SerializeField]
    public bool IsFacingRight=true;
    public Rigidbody2D Rb;
    //输入方向
    [DisplayOnly][SerializeField]
    Vector2 moveInputDir;
    public float MoveInputX{get;private set;}=0;
    public float MoveInputY{get;private set;}=0;
    public bool IsJump{get;private set;}
    public int JumpTimes=0;

    public bool IsGrounded
    {
        get
        {
            if(groundDetect.IsGrounded)
            {
                JumpTimes=Data_Player.JumpTimes;
            }
            return groundDetect.IsGrounded;
        }
    }
    //玩家是否接触到梯子
    public bool IsLadder
    {
        get
        {
            return ladderDetect.IsLadder;
        }
    }
    #endregion

    public Data_Player Data_Player;

    #region FSM
    private FSM fsm;
    public BlackBoard_Player blackBoard;
    #endregion

    Vector2 baseScale;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        baseScale=transform.localScale;
        JumpTimes=Data_Player.JumpTimes;
        playerGO = GameObject.Find("Player");
        inputHandler = GetComponent<PlayerInputHandler>();
        cameraFollowObject=GameObject.Find("CameraFollowPoint").GetComponent<CameraFollowObject>();
        Rb = GetComponent<Rigidbody2D>();

        BodyAnimator = transform.GetChild(0).GetComponent<Animator>();
        if(BodyAnimator==null)
        {
            Debug.LogError("Animator Not Found:Body");
        }
        groundDetect=GetComponentInChildren<GroundDetect>();
        ladderDetect=GetComponentInChildren<LadderDetect>();
        blackBoard.Init(this);

        fsm = new FSM(blackBoard);
        fsm.AddState(StateType.Idle, new Idle_Player(fsm));
        fsm.AddState(StateType.Move, new Move_Player(fsm));
        fsm.AddState(StateType.JumpUp, new JumpUp_Player(fsm));
        fsm.AddState(StateType.JumpDown, new JumpDown_Player(fsm));
        fsm.AddState(StateType.Ladder, new Ladder_Player(fsm));
        fsm.ChangeState(StateType.Idle);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        SetInputValue();
        fsm.OnUpdate();


        //调整朝向
        if(MoveInputX!=0)
        {
            SetFaceDir(MoveInputX);
        }
    }

    private void SetInputValue()
    {
        moveInputDir = inputHandler.MovementValue;
        MoveInputX = moveInputDir.x;
        MoveInputY = moveInputDir.y;
        IsJump = inputHandler.IsJump;
    }



    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        fsm.OnFixedUpdate();
    }

    void SetFaceDir(float _Dir)
    {
        playerGO.transform.localScale = new Vector2(Mathf.Sign(_Dir)*baseScale.x, 1*baseScale.y);
        if(_Dir<0&&IsFacingRight)
        {
            IsFacingRight=false;
            cameraFollowObject.Turn();
        }
        else if(_Dir>0&&!IsFacingRight)
        {
            IsFacingRight=true;
            cameraFollowObject.Turn();
        }
    }

    public void Move(float _StartSpeed,float _TargetSpeed,float _Time,ref float _ElapsedTime)
    {
        if(_ElapsedTime<_Time)
        {
            _ElapsedTime+=Time.fixedDeltaTime;
            float t=_ElapsedTime/_Time;
            float currentSpeed=Mathf.Lerp(_StartSpeed,_TargetSpeed,t);

            Rb.velocity=new Vector2(currentSpeed,Rb.velocity.y);
        }
        else
        {
            Rb.velocity=new Vector2(_TargetSpeed,Rb.velocity.y);
        }
    }


}
