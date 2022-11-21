using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class UIAnimation
{
    #region Visibles
    public static IEnumerator TextInvisible(TMP_Text text, float speed = 1)
    {
        Color color = text.color;
        for (float i = color.a; i > 0; i -= 0.01f * speed)
        {
            color.a = i;
            text.color = color;
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator ImageInvisible(Image image, float multiplier = 1f)
    {
        Color color = image.color;
        float step = 0.01f * multiplier;
        for (float i = color.a; i > 0; i -= step)
        {
            color.a = i;
            image.color = color;
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator RawImageInvisible(RawImage image)
    {
        Color color = image.color;
        for (float i = color.a; i > 0; i -= 0.01f)
        {
            color.a = i;
            image.color = color;
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator TextVisible(TMP_Text text)
    {
        Color color = text.color;
        for (float i = 0; i < 1; i += 0.05f)
        {
            color.a = i;
            text.color = color;
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator ImageVisible(Image image, float maxValue = 1f, float multiplier = 1f)
    {
        Color color = image.color;
        maxValue = color.a;
        float step = 0.05f * multiplier;
        for (float i = 0; i < maxValue; i += step)
        {
            color.a = i;
            image.color = color;
            yield return new WaitForFixedUpdate();
        }
        color.a = maxValue;
        image.color = color;
    }
    #endregion
    #region Scale
    public static IEnumerator UISmoothScale(RectTransform rectTransform, float multiplier, float speed = 1f)
    {
        float startSize = rectTransform.localScale.x;
        float finishSize = rectTransform.localScale.x * multiplier;
        for (float y = 0; y < 1; y += 0.01f * speed)
        {
            float currentScale = Mathf.Lerp(startSize, finishSize, y);
            rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator RepeatPulseEffect(RectTransform rectTransform, float multiplier, float speed = 1, bool isDefaultScale = false)
    {
        float startSize = 0;
        float finishSize = 0;
        if (isDefaultScale == false)
        {
            startSize = rectTransform.localScale.x;
            finishSize = rectTransform.localScale.x * multiplier;
        }
        else
        {
            startSize = 1;
            finishSize = 1 * multiplier;
        }

        float step = 0.01f * speed;
        while (true)
        {
            for (float y = 0; y < 1; y += step)
            {
                float currentScale = Mathf.Lerp(startSize, finishSize, y);
                rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
                yield return new WaitForFixedUpdate();
            }
            for (float i = 0; i < 1; i += step)
            {
                float currentScale = Mathf.Lerp(finishSize, startSize, i);
                rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
                yield return new WaitForFixedUpdate();
            }
        }
    }
    public static IEnumerator RepeatPulseEffect(Transform rectTransform, float multiplier)
    {
        float startSize = rectTransform.localScale.x;
        float finishSize = rectTransform.localScale.x * multiplier;
        float step = 0.01f;
        while (true)
        {
            for (float y = 0; y < 1; y += step)
            {
                float currentScale = Mathf.Lerp(startSize, finishSize, y);
                rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
                yield return new WaitForFixedUpdate();
            }
            for (float i = 0; i < 1; i += step)
            {
                float currentScale = Mathf.Lerp(finishSize, startSize, i);
                rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
                yield return new WaitForFixedUpdate();
            }
        }
    }
    #endregion
    #region Move
    public static IEnumerator SmoothMove(RectTransform rectTransform, Vector3 startPosition, Vector3 targetPosition, float multiply = 1f)
    {
        float step = 0.01f * multiply;
        for (float i = 0; i < 1; i += step)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, i);
            yield return new WaitForFixedUpdate();
        }
        rectTransform.anchoredPosition = targetPosition;
    }
    public static IEnumerator SmoothMoveTudaCuda(RectTransform rectTransform, Vector3 startPosition, Vector3 targetPosition, float multiplier = 1f)
    {
        float step = 0.01f * multiplier;
        while (true)
        {
            for (float i = 0; i < 1; i += step)
            {
                rectTransform.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, i);
                yield return new WaitForFixedUpdate();
            }
            for (float i = 0; i < 1; i += step)
            {
                rectTransform.anchoredPosition = Vector3.Lerp(targetPosition, startPosition, i);
                yield return new WaitForFixedUpdate();
            }
        }
    }
    #endregion
    #region ButtonEffects
    public static IEnumerator OnClickButtonPulseEffect(Image image, float startSize)
    {
        float finishSize = startSize * 2f;
        float step = 0.1f;
        Color color = image.color;
        for (float i = 0; i < 1; i += step)
        {
            float currentScale = Mathf.Lerp(startSize, finishSize, i);
            image.rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);

            color.a = 1f - i;
            image.color = color;
            yield return new WaitForFixedUpdate();
        }
        color.a = 0;
        image.color = color;
    }
    #endregion
    #region Text
    public static IEnumerator TextCountUpdater(TMP_Text text, float targetValue, float speed = 1)
    {
        int.TryParse(text.text, out int tryValue);
        float startValue = tryValue;
        float step = 0.05f * speed;
        for (float i = 0; i < 1; i += step)
        {
            int currentValue = (int)Mathf.Lerp(startValue, targetValue, i);
            text.text = currentValue.ToString();
            yield return new WaitForFixedUpdate();
        }
        text.text = targetValue.ToString();
    }
    public static IEnumerator Countdown(TextMeshProUGUI textMeshPro)
    {
        int count = int.Parse(textMeshPro.text);
        int finish = 0;
        float multiplier = 0.5f;
        RectTransform rectTransform = textMeshPro.GetComponent<RectTransform>();
        for (int i = count; i > finish; i--)
        {
            textMeshPro.text = i.ToString();
            rectTransform.localScale = Vector3.one;
            float startSize = rectTransform.localScale.x;
            float finishSize = startSize * multiplier;

            for (float y = 0; y < 1; y += 0.01f)
            {
                float currentScale = Mathf.Lerp(startSize, finishSize, y);
                rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
                yield return new WaitForFixedUpdate();
            }
        }
    }
    public static IEnumerator ColorBlinkingRepeat(TextMeshProUGUI textMeshProUGUI, Color targetColor)
    {
        Color startColor = textMeshProUGUI.color;
        float step = 0.02f;
        while (true)
        {
            for (float i = 0; i < 1; i += step)
            {
                textMeshProUGUI.color = Color.Lerp(startColor, targetColor, i);
                yield return new WaitForFixedUpdate();
            }
            for (float i = 0; i < 1; i += step)
            {
                textMeshProUGUI.color = Color.Lerp(targetColor, startColor, i);
                yield return new WaitForFixedUpdate();
            }
        }
    }
    #endregion
}