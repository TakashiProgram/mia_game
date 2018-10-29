using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationManager : MonoBehaviour {

    [SerializeField]
    private SkipRayer m_SkipRayer;

    [SerializeField]
    private SceneLoadManager m_ScenemLoadManager;

    [SerializeField]
    private GameObject[] m_ShopList;

    private float m_StartTapPos_X;

    private float m_EndTapPos_X;

    private string DECISION = "Decision";

    private bool m_HitObject = false;

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            m_StartTapPos_X = m_SkipRayer.MousePos().x;
            if (m_SkipRayer.SkipRay().tag == DECISION)
            {
                m_HitObject = true;


            }
        }else if (Input.GetMouseButtonUp(0))
        {
            m_EndTapPos_X = m_SkipRayer.MousePos().x;
            if (m_HitObject == false)
            {
                if (m_StartTapPos_X <= m_EndTapPos_X)
                {
                    Debug.Log("右にスワイプ");
                }
                else if (m_StartTapPos_X >= m_EndTapPos_X)
                {
                    Debug.Log("左にスワイプ");
                }
            }
            m_HitObject = false;
        }
    }
}
