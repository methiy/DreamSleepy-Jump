using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : BaseEnemy
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
}
