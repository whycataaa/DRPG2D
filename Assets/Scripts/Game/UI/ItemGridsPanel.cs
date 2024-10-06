using System;
using UnityEngine;
using UnityEngine.UI;
using MY_FrameWork;


public class ItemGridsPanel : BasePanel
{
    static readonly string path="AssetPackage/UI/Image_ItemGrids";
    //容器ID
    public int GridID;

    /// <summary>
    ///
    /// </summary>
    /// <param name="_ID">背包面板ID</param>
    public ItemGridsPanel(int _ID):base(new UIType(path))
    {
        GridID=_ID;
    }

       Image image_BagGrid;

    Vector2Int bagSize;
    //public BagGrid bagGrid;
    public void Init(Vector2Int _WidthHight)
    {
        bagSize=_WidthHight;
        image_BagGrid=UITool.Instance.FindChildGameObject("Image_Grid").GetComponent<Image>();
    //    bagGrid=image_BagGrid.GetComponent<BagGrid>();
        //调用初始化方法
    //    bagGrid.Init(GridID);
        //初始化格子大小
    //    bagGrid.SetGridWidthAndHeight(_WidthHight);
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnPause()
    {

    }





    internal void PlaceItem(int ItemMod2ID, int posX, int posY)
    {
        
    }

    internal int PickUpItem(int x, int y)
    {
        throw new NotImplementedException();
    }
}
