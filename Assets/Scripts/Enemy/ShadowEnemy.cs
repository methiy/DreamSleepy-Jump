using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowEnemy : BaseEnemy
{
    public float fadeSpeed = 5f; // �����ٶ�����Ӧ1���ת��
    private Image image;
    private bool isFading = false; // �����Ƿ�����ִ�е��뵭��

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(FadeCycle());
    }

    // ��ʼ���뵭��ѭ��
    IEnumerator FadeCycle()
    {
        while (true)
        {
            yield return StartCoroutine(FadeToColor(Color.black, 0.5f)); // 0.5��Ӱ�ɫ����ɫ
            yield return StartCoroutine(FadeToColor(Color.white, 0.5f)); // 0.5��ӵ�ǰ��ɫ����ɫ
        }
    }

    // ���뵽ָ������ɫ
    IEnumerator FadeToColor(Color targetColor, float duration)
    {
        if (isFading) yield break; // ����Ѿ��ڵ��뵭���ˣ��Ͳ��ٿ�ʼ�µ�
        isFading = true;

        float timeElapsed = 0;
        Color startColor = image.color;

        while (timeElapsed < duration)
        {
            image.color = Color.Lerp(startColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        image.color = targetColor; // ȷ�����մﵽĿ����ɫ
        isFading = false;
    }

    void OnDestroy()
    {
        StopAllCoroutines(); // ��������Э��
    }

}
