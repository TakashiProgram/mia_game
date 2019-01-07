using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIManager : MonoBehaviour {

    public void TapEvent()
    {
        Debug.Log(this.GetComponent<Image>().sprite);
    }


}
