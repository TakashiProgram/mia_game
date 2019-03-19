using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{

    private const int POS_SPEED = 6;

    private const int ROT_SPEED = 3;

    public void MovePos(GameObject camera, Vector3 target)
    {
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, target, POS_SPEED * Time.deltaTime);

    }

    public void Rotation(GameObject camera, GameObject target)
    {
        Vector3 target_pos = target.transform.position - camera.transform.position;
        if (null == target_pos)
        {
            return;
        }
        target_pos = Vector3.RotateTowards(camera.transform.forward, target_pos, ROT_SPEED * Time.deltaTime, 10.0F);
        camera.transform.rotation = Quaternion.LookRotation(target_pos);
    }
}
