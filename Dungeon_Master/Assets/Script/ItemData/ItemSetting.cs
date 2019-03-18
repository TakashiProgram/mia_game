using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;
[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class ItemSetting : ScriptableObject
{
    public enum KindOfItem
    {
        Weapon,
        UseItem
    }

    [SerializeField]
    [FormerlySerializedAs("m_KindOfItem")]
    private KindOfItem m_KindOfItem;

    [SerializeField]
    [FormerlySerializedAs("m_IconImage")]
    private Sprite m_IconImage;

    [SerializeField]
    [FormerlySerializedAs("m_Name")]
    private string m_Name;

    [SerializeField]
    [FormerlySerializedAs("m_Information")]
    private string m_Information;

    public KindOfItem GetKindOfItem()
    {
        return m_KindOfItem;
    }

    public Sprite GetIcon()
    {
        return m_IconImage;
    }

    public string GetName()
    {
        return m_Name;
    }

    public string GetInformation()
    {
        return m_Information;
    }
}