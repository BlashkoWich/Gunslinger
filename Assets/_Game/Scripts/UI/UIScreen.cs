using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScreen : MonoBehaviour
{
    [SerializeField]
    private RectTransform _screenRectTransform;
    public RectTransform GetScreenRectTransform => _screenRectTransform;
    [SerializeField]
    private List<Image> _allImages;
    public List<Image> AllImages => _allImages;
    [SerializeField]
    private List<TextMeshProUGUI> _allTexts;
    public List<TextMeshProUGUI> AllTexts => _allTexts;

    public virtual void AllInvisible()
    {
        foreach (var text in AllTexts)
        {
            StartCoroutine(UIAnimation.TextInvisible(text));
        }
        foreach (var image in AllImages)
        {
            StartCoroutine(UIAnimation.ImageInvisible(image));
        }
    }
    public virtual void AllVisible()
    {
        foreach (var text in AllTexts)
        {
            StartCoroutine(UIAnimation.TextVisible(text));
        }
        foreach (var image in AllImages)
        {
            StartCoroutine(UIAnimation.ImageVisible(image));
        }
    }
}
