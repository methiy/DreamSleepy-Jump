using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject background;
    public Animator Animator;
    public Animator Nianshou;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �����ײ�����Ƿ��б�ǩΪ "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��������
            if (background != null)
            {
                Nianshou.SetTrigger("Fail");
                Animator.SetBool("Zhengyan",true);  // �滻Ϊ�㶯���Ĵ���������
            }
            else
            {
                Debug.LogError("Animator is not assigned!");
            }
        }
    }
}
