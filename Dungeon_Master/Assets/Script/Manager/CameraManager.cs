using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private RayCast m_RayCast;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private CameraTransform m_CameraTransform;


    [SerializeField]
    private Camera m_UiCamera;
    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private SceneLoadManager m_ScenemLoadManager;





    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private GameObject[] m_TargetObject;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
    private GameObject m_MoveImage;

    [SerializeField]
    [FormerlySerializedAs("m_ItemDataBase")]
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
        if (true == IsCameraRot())
        {
            m_CameraTransform.Rotation(m_MainCamera, m_TargetObject[m_ShopCount]);
        }

        IsCameraMove(m_MoveLayer, m_ShopMovePos);
        if (null == m_RayCast)
        {
            return;
        }
        GameObject ray_cast = m_RayCast.RayerHitObject();
        if (null == ray_cast)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {

            m_StartTapPos_X = m_RayCast.MousePos().x;
            if (ray_cast.tag == DECISION)
            {
                m_HitObject = true;


            }
            else if (ray_cast.tag == MOVE)
            {
                if (false == m_IsCameraRotation)
                {
                    m_HitObject = true;

                    m_IsCameraMove = true;
                    m_EnterStore = true;

                    if (m_MoveLayer == UP_MOVE)
                    {
                        m_MoveLayer = DOWN_MOVE;
                        m_ShopMovePos = m_TargetObject[m_ShopCount].transform.position;

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
                m_EndTapPos_X = m_RayCast.MousePos().x;


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
    private bool IsCameraRot()
    {
        if (m_MainCamera.gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            return false;
        }

        return true;
    }

    private void IsCameraMove(int layer_count, Vector3 tager)
    {
        if (true == m_IsCameraMove)
        {
            m_CameraTransform.MovePos(m_MainCamera, tager);
            m_MoveImage.layer = layer_count;
            m_UiCamera.enabled = false;
            m_TargetObject[m_ShopCount].SetActive(false);
            StartCoroutine(TargetMoveTo(tager.z));

        }
    }
    private IEnumerator TargetMoveTo(float value)
    {
        yield return null;
        if (true == IsCameraRot())
        {
            yield break;
        }
        m_IsCameraMove = false;
        m_UiCamera.enabled = true;

        if (value == 0)
        {
            m_TargetObject[m_ShopCount].SetActive(false);

            m_HitObject = false;
            m_EnterStore = false;
        }
        else
        {
            m_TargetObject[m_ShopCount].SetActive(true);
        }
    }

}
