using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowEnemy : BaseEnemy
{
    public float fadeSpeed = 5f; // �����ٶ�����Ӧ1���ת��
    [SerializeField]private Image image;
    private bool isFading = false; // �����Ƿ�����ִ�е��뵭��

    void Start()
    {
        image = Camera.main.GetComponent<Image>();
    }

    

}
