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
    //下落最大速度
    public float JumpDownMaxSpeed;
    public int JumpTimes;
    [Header("Ladder")]
    public float LadderMoveSpeedX;
    public float LadderMoveSpeedY;

}
