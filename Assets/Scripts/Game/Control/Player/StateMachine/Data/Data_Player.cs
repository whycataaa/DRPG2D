using UnityEngine;


/// <summary>
/// 管理静态可配置数据
/// </summary>
[CreateAssetMenu(fileName = "Data_Player", menuName = "Data/Data_Player")]
public class Data_Player : ScriptableObject
{
    [Header("Movement")]
    [Header("Run")]
    public float MoveSpeed;
    public float ToTargetTime;

    [Header("Idle")]
    public float StopTime;
    [Header("Jump")]
    public float JumpUpMaxSpeed;
    public float JumpToMinTime;
    //向前速度
    public float JumpMoveSpeed;
    //向后速度
    public float JumpMoveSpeedBack;
    public int JumpTimes;
    [Header("Ladder")]
    public float LadderMoveSpeedX;
    public float LadderMoveSpeedY;
    [Header("Battle")]
    public float BattleMoveSpeed;
}
