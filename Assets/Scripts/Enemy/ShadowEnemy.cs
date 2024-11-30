using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowEnemy : BaseEnemy
{
    public float fadeSpeed = 5f; // 增加速度以适应1秒的转换
    private Image image;
    private bool isFading = false; // 控制是否正在执行淡入淡出

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(FadeCycle());
    }

    // 开始淡入淡出循环
    IEnumerator FadeCycle()
    {
        while (true)
        {
            yield return StartCoroutine(FadeToColor(Color.black, 0.5f)); // 0.5秒从白色到黑色
            yield return StartCoroutine(FadeToColor(Color.white, 0.5f)); // 0.5秒从当前颜色到白色
        }
    }

    // 淡入到指定的颜色
    IEnumerator FadeToColor(Color targetColor, float duration)
    {
        if (isFading) yield break; // 如果已经在淡入淡出了，就不再开始新的
        isFading = true;

        float timeElapsed = 0;
        Color startColor = image.color;

        while (timeElapsed < duration)
        {
            image.color = Color.Lerp(startColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        image.color = targetColor; // 确保最终达到目标颜色
        isFading = false;
    }

    void OnDestroy()
    {
        StopAllCoroutines(); // 清理所有协程
    }

}
