using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;
    private Vector3 speed;
    private void LateUpdate()
    {
        if(target.position.y > transform.position.y)
        {
            Vector3 targetPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed * Time.deltaTime);
        }
    }

    public void FollowDoodler(){
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed * Time.deltaTime);
    }

}
