using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UnityEventTap : MonoBehaviour {

    public UnityEvent OnTap;
	

	private void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (OnTap != null)
            {
                OnTap.Invoke();
            }
        }
	}

    //private bool OnTouchDown()
    //{
    //    if (0 < Input.touchCount)
    //    {

    //    }
    //}
}
