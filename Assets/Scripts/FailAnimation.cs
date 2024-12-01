using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailAnimation : MonoBehaviour
{
    public Animator animator;      // ��Ҫ���ŵĶ���������
    public float timeWithoutCollision = 0.5f; // û����ײ�ĵȴ�ʱ�䣬��λ��
    public GameObject Heixian;

    private float collisionTimer = 0f; // ��ʱ��

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
        // ����������ײ��Ӵ�ʱ�����ü�ʱ��
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
