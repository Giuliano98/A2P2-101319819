using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    private Image fadeImage;
    public float fadeDuration = 1.0f;

    public GameObject UI_btns;
    private void Start()
    {
        fadeImage = GetComponent<Image>();

        fadeImage.color = new Color(0f, 0f, 0f, 0f);
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0f, 1f));
    }

    IEnumerator Fade(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color currentColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            currentColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeImage.color = currentColor;
            yield return null;
        }
    }
}
