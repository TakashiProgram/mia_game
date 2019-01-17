using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGenerationer : MonoBehaviour {

    [SerializeField]
    private GameObject m_PurchaseItem;

    [SerializeField]
    private Canvas m_Canvas;

    private GameObject obj;

    private void Update()
    {
        if (obj != null)
        {
            obj.transform.position = Input.mousePosition;
        }
        
    }

    public void Generationer()
    {
      obj = Instantiate(m_PurchaseItem);

        obj.transform.parent = this.transform;
        
    }

    public void Destroy()
    {
        Destroy(obj); 
    }
}
