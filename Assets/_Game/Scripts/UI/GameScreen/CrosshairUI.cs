using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CrosshairUI
{
    [SerializeField]
    private RectTransform _rectTransform;

    private Vector3 _targetScale = Vector3.one;

    public void IncreaseScale()
    {
        float deltaScale = 0.05f;

        _targetScale += new Vector3(deltaScale, deltaScale, deltaScale);
    }
    public void ResetScale()
    {
       _targetScale = Vector3.one;
    }
    public void Update()
    {
        if (Vector3.Distance(_rectTransform.localScale, _targetScale) > 0.02f)
        {
            _rectTransform.localScale = Vector3.Lerp(_rectTransform.localScale, _targetScale, 6 * Time.deltaTime);
        }
    }
    public void Toogle(bool isActivate)
    {
        _rectTransform.gameObject.SetActive(isActivate);
    }
}
