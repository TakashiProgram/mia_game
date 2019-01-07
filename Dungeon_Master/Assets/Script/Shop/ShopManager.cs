using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    [SerializeField]
    private Image[] m_Item;

    [SerializeField]
    private ItemDataBase m_ItemDataBase;

	void Start () {
        for (int i = 0; i < m_Item.Length; i++)
        {
            m_Item[i].sprite = m_ItemDataBase.GetItemLists()[i].GetIcon();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
