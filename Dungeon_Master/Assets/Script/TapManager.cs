using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class TapManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoadManager m_ScenemLoadManager;

    private string LOAD_SELECT = "LoadSelect";

    private float m_StartTapPos_X;

    private float m_EndTapPos_X;

    private void Start()
    {

    }

    private void Update()
    {
        TapRay();
    }

    private void TapRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            m_StartTapPos_X = Input.mousePosition.x;
            
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.name == LOAD_SELECT)
                {

                    m_ScenemLoadManager.SceneLoad(hit.collider.gameObject.tag);

                }
            }

        }
        else if(Input.GetMouseButtonUp(0))
        {
            m_EndTapPos_X = Input.mousePosition.x;
            if (m_StartTapPos_X <= m_EndTapPos_X)
            {
                Debug.Log("右にスワイプ");
            }
            else if(m_StartTapPos_X >= m_EndTapPos_X)
            {
                Debug.Log("左にスワイプ");
            }
        }
    }

}