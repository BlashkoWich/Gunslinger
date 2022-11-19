using System;

public interface IPoolable
{
    public abstract event Action OnAddToPool;

    public string GetName { get; }
}
