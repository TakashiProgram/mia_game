using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    private static int SPEED = 3;

	public void Rotation(GameObject main_camera,GameObject shop_rist)
    {
        Vector3 target = shop_rist.transform.position - main_camera.transform.position;

        float speed = SPEED * Time.deltaTime;

        Vector3 newtarget = Vector3.RotateTowards(main_camera.transform.forward, target, speed, 10.0F);
        main_camera.transform.rotation = Quaternion.LookRotation(newtarget);
    }
}
