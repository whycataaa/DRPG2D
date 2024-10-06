
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg.item
{
public partial class TbItem
{
    private readonly System.Collections.Generic.Dictionary<int, item.Item> _dataMap;
    private readonly System.Collections.Generic.List<item.Item> _dataList;
    
    public TbItem(JSONNode _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, item.Item>();
        _dataList = new System.Collections.Generic.List<item.Item>();
        
        foreach(JSONNode _ele in _buf.Children)
        {
            item.Item _v;
            { if(!_ele.IsObject) { throw new SerializationException(); }  _v = item.Item.DeserializeItem(_ele);  }
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, item.Item> DataMap => _dataMap;
    public System.Collections.Generic.List<item.Item> DataList => _dataList;

    public item.Item GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public item.Item Get(int key) => _dataMap[key];
    public item.Item this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

