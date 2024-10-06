using System.IO;
using SimpleJSON;
using UnityEngine;
using cfg;
public class ExcTest : MonoBehaviour
{
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        string ConfigDir= Application.streamingAssetsPath+"/Luban";
        var tables=new cfg.Tables(file=>JSON.Parse(File.ReadAllText($"{ConfigDir}/{file}.json")));

        var item = tables.TbItem.DataList[9];
        Debug.Log(item.Name);
    }
}
