using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowEnemy : BaseEnemy
{
    public float fadeSpeed = 5f; // 增加速度以适应1秒的转换
    [SerializeField]private Image image;
    private bool isFading = false; // 控制是否正在执行淡入淡出

    void Start()
    {
        image = Camera.main.GetComponent<Image>();
    }

    

}
