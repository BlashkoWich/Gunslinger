using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactObject : MonoBehaviour, IPoolable
{
    public event Action OnAddToPool;

    public string GetName => gameObject.name;

    private Coroutine _timer;

    public void Activate()
    {
        gameObject.SetActive(true);

        if(_timer != null)
        {
            StopCoroutine(_timer);
        }
        _timer = StartCoroutine(TimerToDisactivate());
        IEnumerator TimerToDisactivate()
        {
            yield return new WaitForSeconds(10f);
            OnAddToPool?.Invoke();
        }
    }
}
