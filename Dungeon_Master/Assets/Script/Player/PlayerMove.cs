using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Move(Vector2 pos)
    {
        //ダメ　違うやり方にする
        Vector3 current = this.transform.position;
        current += new Vector3(pos.x, 0, pos.y);
        this.transform.position = current;
    }
}
