using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class SetItemData : MonoBehaviour
{

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private Image[] m_Item;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private ItemDataBase m_ItemDataBase;

    void Start()
    {
        for (int i = 0; i < m_Item.Length; i++)
        {
            m_Item[i].sprite = m_ItemDataBase.GetItem()[i].GetIcon();

            m_Item[i].name = m_ItemDataBase.GetItem()[i].GetName();
        }

    }
    public ItemSetting GetItem(string searchName)
    {
        return m_ItemDataBase.GetItem().Find(itemName => itemName.GetName() == searchName);
    }

}
