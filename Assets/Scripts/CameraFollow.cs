using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 speed;
    
    // [HideInInspector] 
    public States state = States.Normal;
    public enum States{
        Normal, Falling, Uping
    }

    private Rigidbody2D playerRb;

    [SerializeField]private float colliderHeight;

    // Start is called before the first frame update
    void Start(){
        playerRb = target.GetComponent<Rigidbody2D>();
    }

    // Camera follow states
    void LateUpdate(){
        float targetPosY = target.transform.position.y;
        float camPosY = transform.position.y;
        if(targetPosY + colliderHeight/2 <= camPosY){
            state = States.Falling;
        }
        else if(state != States.Falling && targetPosY > camPosY){
            state  = States.Uping;
        }else if(state != States.Falling){
            state = States.Normal;
        }
        if(state == States.Uping){
            FollowDoodler(0.3f, 0f);
        }else if(state == States.Falling){
            FollowDoodler(playerRb.velocity.y * 0.95f, -2f);
        }
    }

    private void FollowDoodler(float smoothSpeed, float border){
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y - border, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed * Time.deltaTime);
    }

}
