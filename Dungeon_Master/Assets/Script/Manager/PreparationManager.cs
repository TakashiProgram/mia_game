using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationManager : MonoBehaviour
{

    [SerializeField]
    private SkipRayer m_SkipRayer;

    [SerializeField]
    private SceneLoadManager m_ScenemLoadManager;

    [SerializeField]
    private CameraRotation m_CameraRotation;

    [SerializeField]
    private CameraMover m_CameraMover;

    [SerializeField]
    private GameObject[] m_ShopList;

    [SerializeField]
    private GameObject m_MoveImage;

    [SerializeField]
    private GameObject m_MainCamera;

    private Vector3 m_StartPos;

    private float m_StartTapPos_X;

    private float m_EndTapPos_X;

    private static string DECISION = "Decision";

    private static string MOVE = "Move";

    private static int UP_MOVE = 10;

    private static int DOWN_MOVE = 11;

    private int m_MoveLayer = 0;

    private Vector3 m_ShopMovePos;

    private bool m_HitObject = false;

    private bool m_EnterStore = false;

    private bool m_IsCameraRotation = false;

    private bool m_IsCameraMove = false;

    private int m_ShopCount = 0;

    private int m_Rotation = 0;

    private int m_TagCount = 0;

    void Start()
    {
        m_MoveLayer = UP_MOVE;

        m_StartPos = m_MainCamera.transform.position;
        
    }

    void Update()
    {

        IsCameraRotation();
        IsCameraMove(m_MoveLayer, m_ShopMovePos);

        if (Input.GetMouseButtonDown(0))
        {

            m_StartTapPos_X = m_SkipRayer.MousePos().x;
            if (m_SkipRayer.SkipRay().tag == DECISION)
            {
                m_HitObject = true;


            }else if (m_SkipRayer.SkipRay().tag == MOVE)
            {
                if (false == m_IsCameraRotation)
                {
                    m_HitObject = true;

                    m_IsCameraMove = true;
                    m_EnterStore = true;

                    if (m_MoveLayer == UP_MOVE)
                    {
                        m_MoveLayer = DOWN_MOVE;
                        m_ShopMovePos = m_ShopList[m_ShopCount].transform.position;
                       
                    }
                    else
                    {
                        m_MoveLayer = UP_MOVE;
                        m_ShopMovePos = m_StartPos;
                        
                       
                    }

                }
               
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (false == m_HitObject)
            {
                m_EndTapPos_X = m_SkipRayer.MousePos().x;


                m_MainCamera.transform.rotation = Quaternion.Euler(new Vector3(0, (m_StartTapPos_X - m_EndTapPos_X) / 10 + m_Rotation, 0));

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            if (false == m_HitObject)
            {
                if (m_StartTapPos_X + 300 <= m_EndTapPos_X)
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
                else
                {
                    m_IsCameraRotation = true;
                }
                if (m_StartTapPos_X - 300 >= m_EndTapPos_X)
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
                else
                {
                    m_IsCameraRotation = true;
                }


            }
            if (m_EnterStore == false)
            {
                m_HitObject = false;
            }
           
        }
    }

    private void IsCameraRotation()
    {
        if (true == m_IsCameraRotation)
        {

            m_CameraRotation.Rotation(m_MainCamera, m_ShopList[m_ShopCount]);
            if (m_MainCamera.gameObject.GetComponent<Rigidbody>().IsSleeping())
            {
                m_IsCameraRotation = false;
            }
        }
    }

    private void IsCameraMove(int layer_count,Vector3 tager)
    {
        if (true == m_IsCameraMove)
        {
            m_CameraMover.Move(m_MainCamera, tager);
            m_MoveImage.layer = layer_count;
            this.gameObject.GetComponent<Camera>().enabled = false;
            m_ShopList[m_ShopCount].SetActive(false);
            StartCoroutine(ShopMove(tager.z));

        }
    }
    private IEnumerator ShopMove(float value)
    {
        yield return null;
        if (m_MainCamera.gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
           
            m_IsCameraMove = false;
            this.gameObject.GetComponent<Camera>().enabled = true;

            if (value == 0)
            {
                m_ShopList[m_ShopCount].SetActive(false);

                m_HitObject = false;
                m_EnterStore = false;
            }
            else
            {
                m_ShopList[m_ShopCount].SetActive(true);
            }
            

        }
    }

}
