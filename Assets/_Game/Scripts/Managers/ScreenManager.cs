using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private UIScreen[] _screens;

    public T GetScreen<T>() where T : UIScreen
    {
        foreach (var screen in _screens)
            if (screen is T)
                return (T)screen;
        return null;
    }

    public void Switch<T>() where T : UIScreen
    {
        foreach (var screen in _screens)
        {
            if (screen is T)
                screen.gameObject.SetActive(true);
            else
                screen.gameObject.SetActive(false);
        }
    }
    public IEnumerator SmoothSwitch<T>(bool isSkipSmoothOffCurrentScreen = false) where T : UIScreen
    {
        UIScreen currentScreen = null;
        UIScreen targetScreen = null;
        foreach (var screen in _screens)
        {
            if (screen is T)
                targetScreen = screen;
            if (screen.gameObject.activeInHierarchy == true)
                currentScreen = screen;
        }
        currentScreen.AllInvisible();
        if (isSkipSmoothOffCurrentScreen == false)
        {
            Debug.Log("DontSkip");
            yield return new WaitForSecondsRealtime(2f);
        }
        else
        {
            yield return new WaitForFixedUpdate();
        }
        currentScreen.gameObject.SetActive(false);
        targetScreen.gameObject.SetActive(true);
        targetScreen.AllVisible();
    }
}
