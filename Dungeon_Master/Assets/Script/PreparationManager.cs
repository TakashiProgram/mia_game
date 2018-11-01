using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationManager : MonoBehaviour {

    [SerializeField]
    private SkipRayer m_SkipRayer;

    [SerializeField]
    private SceneLoadManager m_ScenemLoadManager;

    [SerializeField]
    private CameraRotation m_CameraRotation;

    [SerializeField]
    private GameObject[] m_ShopList;

    [SerializeField]
    private GameObject m_MainCamera;
   
    private float m_StartTapPos_X;

    private float m_EndTapPos_X;

    private static string DECISION = "Decision";

    private bool m_HitObject = false;

    private bool m_IsCameraRotation = false;

    private int m_ShopCount = 0;

    private int m_Rotation=0;
    
    void Start () {
		
	}
	
	void Update () {

        IsCameraRotation();

        if (Input.GetMouseButtonDown(0))
        {

            m_StartTapPos_X = m_SkipRayer.MousePos().x;
            if (m_SkipRayer.SkipRay().tag == DECISION)
            {
                m_HitObject = true;


            }

        }
        else if (Input.GetMouseButton(0))
        {

            m_EndTapPos_X = m_SkipRayer.MousePos().x;


            m_MainCamera.transform.rotation = Quaternion.Euler(new Vector3(0, (m_StartTapPos_X - m_EndTapPos_X) /10  + m_Rotation, 0));
           
        }else if (Input.GetMouseButtonUp(0))
        {

            if (m_HitObject == false)
            {
                if (m_StartTapPos_X <= m_EndTapPos_X)
                {
                    m_IsCameraRotation = true;
                  
                    m_ShopCount--;
                    m_Rotation -= 90;
                    if (m_ShopCount == -1)
                    {
                        m_ShopCount = 3;
                        m_Rotation = 270;
                    }


                }
                else if (m_StartTapPos_X >= m_EndTapPos_X)
                {
                    m_IsCameraRotation = true;

                    m_ShopCount++;
                    m_Rotation += 90;
                    if (m_ShopCount == 4)
                    {
                        m_ShopCount = 0;
                        m_Rotation = 0;
                    }

                }

             
            }
            m_HitObject = false;
        }
    }

    private void IsCameraRotation()
    {
        if (m_IsCameraRotation)
        {
            
            m_CameraRotation.Rotation(m_MainCamera, m_ShopList[m_ShopCount]);
            if (m_MainCamera.gameObject.GetComponent<Rigidbody>().IsSleeping())
            {
                m_IsCameraRotation = false;
            }
        }

        


    }




}
