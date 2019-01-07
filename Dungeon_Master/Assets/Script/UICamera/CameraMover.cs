
using UnityEngine;

public class CameraMover : MonoBehaviour {

    private static int SPEED = 6;

    public void Move(GameObject main_camera , Vector3 taget)
    {
        float step = SPEED * Time.deltaTime;
        main_camera.transform.position = Vector3.MoveTowards(main_camera.transform.position, taget, step);
      
    }
}
