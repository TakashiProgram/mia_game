using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour {
    [SerializeField]
    private Vector2 m_Range;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector2 GetRange()
    {
        return m_Range;
    }
}
