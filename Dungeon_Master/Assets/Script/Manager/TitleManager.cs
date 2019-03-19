using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    [SerializeField]
    private RayCast m_RayCast;

    [SerializeField]
    private SceneLoadManager m_ScenemLoadManager;

    private string PREPARATION = "Preparation";

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_RayCast.RayerHitObject().tag == PREPARATION)
            {

                m_ScenemLoadManager.SceneLoad(m_RayCast.RayerHitObject().tag);
            }
        }

    }
}
