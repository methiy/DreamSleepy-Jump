using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : BaseEnemy
{
    public float speed = 1f; // 移动速度
    public float distance = 1f; // 巡逻距离的一半
    private Vector3 startPos;
    private bool movingRight = true;

    private void Start()
    {
        startPos = transform.position; // 获取初始位置
    }

    private void Update()
    {
        if (movingRight)
        {
            // 向右移动
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x + distance)
            {
                movingRight = false; // 改变方向
            }
        }
        else
        {
            // 向左移动
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x - distance)
            {
                movingRight = true; // 改变方向
            }
        }
    }
}
