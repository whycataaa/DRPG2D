using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//物品类
public class Item
{
    //物品唯一ID
    public int ID;
    //物品名称
    public string Name;
    //物品图片宽
    public int Width;
    //物品图片高
    public int Height;
    //物品类型
    public ItemType Type;
    //物品描述
    public string Description;
    //物品最大堆叠数
    public int MaxCount;
}

public enum ItemType
{
    Weapon,
    Armor,
    Consumable
}