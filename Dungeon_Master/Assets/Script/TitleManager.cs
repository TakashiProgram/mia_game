using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    [SerializeField]
    private SkipRayer m_SkipRayer;

    [SerializeField]
    private SceneLoadManager m_ScenemLoadManager;

    private string PREPARATION = "Preparation";

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_SkipRayer.SkipRay().tag == PREPARATION)
            {

                m_ScenemLoadManager.SceneLoad(m_SkipRayer.SkipRay().tag);
            }
        }

    }
}
