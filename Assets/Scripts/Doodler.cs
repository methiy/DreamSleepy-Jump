using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodler : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public GameObject mainCamera;
    [SerializeField]private float colliderHeight;
    [SerializeField]private float fallTime;

    [SerializeField]private bool isFall;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderHeight= mainCamera.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if(h != 0)
        {
            transform.localScale = new Vector3(-h, 1, 1);
        }

        if(fallTime > 0 && transform.position.y + colliderHeight/2 < mainCamera.transform.position.y){
            isFall = true;
            fallTime -= Time.deltaTime;
            mainCamera.GetComponent<CameraFollow>()?.FollowDoodler();
            if(fallTime < 0){
                GameOver();
            }
        }else{
            isFall = false;
        }
    }

    private void GameOver(){
        Debug.Log("GameOver");
    }
}
