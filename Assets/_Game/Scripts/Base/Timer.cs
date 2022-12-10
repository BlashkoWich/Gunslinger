using System;
using UnityEngine;

public class Timer : Watch
{
    public override event Action<float> OnUpdateTime;
    public override event Action OnEndTimer;

    public override void UpdateTime(float deltaTime)
    {
        if (_isEnd == true)
        {
            return;
        }

        currentTime -= deltaTime;
        OnUpdateTime?.Invoke(currentTime);

        if (currentTime <= 0)
        {
            _isEnd = true;
            OnEndTimer?.Invoke();
        }
    }
}

public class Stopwatch : Watch
{
    public override event Action<float> OnUpdateTime;
    public override event Action OnEndTimer;
    public event Action OnPreBoss;

    private float _targetTime;

    public override void SetTime(float time)
    {
        _targetTime = time;
        currentTime = 0;
        _isEnd = false;
    }

    public override void UpdateTime(float deltaTime)
    {
        if (_isEnd == true)
        {
            return;
        }

        currentTime += deltaTime;
        OnUpdateTime?.Invoke(currentTime);

        if (currentTime >= _targetTime)
        {
            _isEnd = true;
            OnEndTimer?.Invoke();
        }

        if (currentTime >= _targetTime - 7)
        {
            Debug.Log("StartTimer");
            OnPreBoss?.Invoke();
        }
    }
}

public abstract class Watch
{
    public abstract event Action<float> OnUpdateTime;
    public abstract event Action OnEndTimer;

    public float currentTime { get; protected set; }
    protected bool _isEnd;


    public virtual void SetTime(float time)
    {
        currentTime = time;
        _isEnd = false;
    }

    public abstract void UpdateTime(float deltaTime);
}