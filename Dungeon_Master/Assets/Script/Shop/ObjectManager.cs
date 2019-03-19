using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class ObjectManager : MonoBehaviour
{

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private GameObject m_PurchaseItem;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private Canvas m_Canvas;

    private GameObject obj;

    private void Update()
    {
        if (obj != null)
        {
            obj.transform.position = Input.mousePosition;
        }

    }

    public void Create(Sprite image)
    {
        obj = Instantiate(m_PurchaseItem);

        obj.transform.parent = this.transform;

        obj.GetComponent<Image>().sprite = image;


    }

    public void Destroy()
    {
        //仮で消している
        // obj.GetComponent<PassThing>().Hit();

        Destroy(obj);
    }
}
