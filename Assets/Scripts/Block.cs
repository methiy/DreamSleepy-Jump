using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject background;
    public Animator Animator;
    public Animator Nianshou;
    public GameObject Jiesuan;
    public Animator Score;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞对象是否有标签为 "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // 触发动画
            if (background != null)
            {
                Nianshou.SetTrigger("Fail");
                Animator.SetBool("Zhengyan",true);
                Jiesuan.SetActive(true);
                Score.SetTrigger("Jiesuan");
            }
            else
            {
                Debug.LogError("Animator is not assigned!");
            }
        }
    }
}
