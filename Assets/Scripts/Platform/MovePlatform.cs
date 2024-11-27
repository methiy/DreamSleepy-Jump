using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : Platform
{
   public float speed = 1f; // �ƶ��ٶ�
    public float distance = 1f; // Ѳ�߾����һ��
    private Vector3 startPos;
    private bool movingRight = true;

    private void Start()
    {
        startPos = transform.position; // ��ȡ��ʼλ��
    }

    private void Update()
    {
        if (movingRight)
        {
            // �����ƶ�
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x + distance)
            {
                movingRight = false; // �ı䷽��
            }
        }
        else
        {
            // �����ƶ�
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x - distance)
            {
                movingRight = true; // �ı䷽��
            }
        }
    }

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal == Vector2.down)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = Vector2.up * bounceSpeed;
            }
        }
    }
}
