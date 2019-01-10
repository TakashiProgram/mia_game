using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIManager : MonoBehaviour {
    [SerializeField]
    private ShopManager m_ShopManager;

    [SerializeField]
    private ShowCharacters m_ShowCharacters;

    [SerializeField]
    private Text m_ItemDescription;

    public void TapEvent()
    {
        m_ItemDescription.text = "アイテム名\n" + m_ShopManager.GetItem(this.name).GetInformation();

        m_ShowCharacters.SetNextSentence(m_ItemDescription.text);
    }
}
