using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailAnimation : MonoBehaviour
{
    public Animator animator;      // 绑定要播放的动画控制器
    public float timeWithoutCollision = 0.5f; // 没有碰撞的等待时间，单位秒
    public GameObject Heixian;

    private float collisionTimer = 0f; // 计时器

    void Update()
    {
        if (collisionTimer >= timeWithoutCollision)
        {
            TriggerAnimation();
            Heixian.SetActive(true);
        }
        else
        {
            collisionTimer += Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    
        {
        // 当物体与碰撞体接触时，重置计时器
        collisionTimer = 0f;
    }

    void TriggerAnimation()
    {

        if (animator != null)
        {
            animator.SetTrigger("Fail"); 
        }
    }
}
