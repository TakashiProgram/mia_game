using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private ItemDataBase m_ItemDataBase;

    private Dictionary<ItemSetting, int> m_NumOfItem = new Dictionary<ItemSetting, int>();

    void Start()
    {
        if (null == m_ItemDataBase)
        {
            return;
        }

        for (int i = 0; i < m_ItemDataBase.GetItem().Count; i++)
        {

            Debug.Log(m_ItemDataBase.GetItem()[i].GetName() + ": " + m_ItemDataBase.GetItem()[i].GetInformation());
        }

        Debug.Log(GetItem("アイアンソード").GetInformation());
        Debug.Log(m_NumOfItem[GetItem("アイアンソード")]);



    }

    public ItemSetting GetItem(string searchName)
    {
        return m_ItemDataBase.GetItem().Find(itemName => itemName.GetName() == searchName);
    }
}