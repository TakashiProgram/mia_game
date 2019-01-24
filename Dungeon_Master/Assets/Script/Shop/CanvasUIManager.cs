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

    [SerializeField]
    private ObjectGenerationer m_ObjectGenerationer;

    public void TapDownEvent()
    {
        m_ItemDescription.text = "アイテム名\n" + m_ShopManager.GetItem(this.name).GetInformation();

        m_ShowCharacters.SetNextSentence(m_ItemDescription.text);

        this.GetComponent<Image>().color = new Color(1,1,1,0.5f);

        m_ObjectGenerationer.Generationer(m_ShopManager.GetItem(this.name).GetIcon());
    }

    public void TapUpEvent()
    {
        this.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        m_ObjectGenerationer.Destroy();
    }
}
