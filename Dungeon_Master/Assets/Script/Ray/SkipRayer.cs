using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipRayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject SkipRay()
    {

        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        

        if (Physics.Raycast(ray, out hit))
        {

            Debug.Log(hit.collider.gameObject);
            return hit.collider.gameObject;
        }
        return this.gameObject;
    }

    public Vector3 MousePos()
    {
        return Input.mousePosition;
    }
}
