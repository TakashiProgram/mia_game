using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassThing : MonoBehaviour {

    [SerializeField]
    private Sprite m_PassThing;

    [SerializeField]
    private Sprite image;

    private GameObject m_HitObject;
    void Start () {
        image = this.gameObject.GetComponent<Image>().sprite;

    }
	
	// Update is called once per frame
	void Update () {
       
	}
   //自分のアイテムリストにどうやって入れるのか
    private void OnTriggerEnter(Collider other)
    {
        m_PassThing = image;


        m_HitObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        m_PassThing = null;
    }

    public void Hit()
    {
        if (m_PassThing !=null)
        {
            m_HitObject.GetComponent<Image>().sprite = image;
        }
    }
}
