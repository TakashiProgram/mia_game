using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField]
    private PlayerMove m_PlayerMove;
    
    [SerializeField]
    private RayCast m_RayCast;
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(m_RayCast.RayerHitObject());
            PlayerRange range = m_RayCast.RayerHitObject().GetComponent<PlayerRange>();
            m_PlayerMove.Move(range.GetRange());
        }

    }
}
