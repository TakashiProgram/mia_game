using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
public class UITapEvent : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private SetItemData m_SetItemData;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private TextSetting m_TextSetting;

     [SerializeField]
     private Text m_ItemDescription;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private ObjectManager m_ObjectManager;

    public void TapDownEvent()
    {
        //string m_ItemDescription = "アイテム名\n" + m_ShopManager.GetItem(this.name).GetInformation();
        string description = "アイテム名\n" + m_SetItemData.GetItem(this.name).GetInformation();
        if (null == description)
        {
            return;
        }
        m_TextSetting.SetNextSentence(description);

        this.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);

        m_ObjectManager.Create(m_SetItemData.GetItem(this.name).GetIcon());
    }

    public void TapUpEvent()
    {
        this.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        m_ObjectManager.Destroy();
    }
}
