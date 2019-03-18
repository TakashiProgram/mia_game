using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField]
    [FormerlySerializedAs("m_Item")]
    private List<ItemSetting> m_Item = new List<ItemSetting>();

    public List<ItemSetting> GetItem()
    {
        return m_Item;
    }
}