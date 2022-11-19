using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public event Action OnBackInPool;
    public event Action<int, Type> OnNeedObjects;
    public event Action<IPoolable> OnAddObject;

    private List<Node> _nodes = new List<Node>();

    private class Node
    {
        public Node(IPoolable newProjectile)
        {
            poolObject = newProjectile;
            isReady = true;
        }

        public IPoolable poolObject;
        public bool isReady;
    }
    public void AddObject(IPoolable poolable)
    {
        _nodes.Add(new Node(poolable));
        OnAddObject?.Invoke(poolable);
    }

    public List<IPoolable> GetFreeObjects(int count, Type type)
    {
        int freeCount = GetSpecificCountFreePoolable(type);
        if (freeCount < count)
        {
            OnNeedObjects?.Invoke(count - freeCount, type);
        }

        List<IPoolable> poolObject = new List<IPoolable>();

        foreach (var pool in _nodes)
        {
            if (pool.isReady && pool.poolObject.GetType() == type)
            {
                poolObject.Add(pool.poolObject);
                pool.isReady = false;
                pool.poolObject.OnAddToPool += EndLifeTime;

                if (poolObject.Count >= count)
                {
                    return poolObject;
                }
                void EndLifeTime()
                {
                    pool.poolObject.OnAddToPool -= EndLifeTime;
                    pool.isReady = true;
                    OnBackInPool?.Invoke();
                }
            }
        }

        return poolObject;
    }
    public List<IPoolable> GetFreeObjects(int count)
    {
        int freeCount = _getCountFreePoolables;
        if (freeCount < count)
        {
            OnNeedObjects?.Invoke(count - freeCount, null);
        }

        List<IPoolable> poolObject = new List<IPoolable>();

        foreach (var pool in _nodes)
        {
            if (pool.isReady)
            {
                poolObject.Add(pool.poolObject);
                pool.isReady = false;
                pool.poolObject.OnAddToPool += EndLifeTime;

                if (poolObject.Count >= count)
                {
                    return poolObject;
                }

                void EndLifeTime()
                {
                    pool.poolObject.OnAddToPool -= EndLifeTime;
                    pool.isReady = true;
                    OnBackInPool?.Invoke();
                }
            }
        }

        return poolObject;
    }
    public List<IPoolable> GetFreeObjects(int count, string name)
    {
        int freeCount = _getCountFreePoolables;
        if (freeCount < count)
        {
            OnNeedObjects?.Invoke(count - freeCount, null);
        }

        List<IPoolable> poolObject = new List<IPoolable>();

        name += "(Clone)";
        foreach (var pool in _nodes)
        {
            if (pool.isReady && pool.poolObject.GetName == name)
            {
                poolObject.Add(pool.poolObject);
                pool.isReady = false;
                pool.poolObject.OnAddToPool += EndLifeTime;

                if (poolObject.Count >= count)
                {
                    return poolObject;
                }

                void EndLifeTime()
                {
                    pool.poolObject.OnAddToPool -= EndLifeTime;
                    pool.isReady = true;
                    OnBackInPool?.Invoke();
                }
            }
        }

        return poolObject;
    }
    private int _getCountFreePoolables
    {
        get
        {
            int count = 0;
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].isReady)
                {
                    count++;
                }
            }
            return count;
        }
    }
    public IPoolable GetFreeObject(Type type)
    {
        List<IPoolable> poolables = GetFreeObjects(1, type);
        return poolables[0];
    }
    private int GetSpecificCountFreePoolable(Type type)
    {
        int count = 0;
        for (int i = 0; i < _nodes.Count; i++)
        {
            if (_nodes[i].isReady)
            {
                if (_nodes[i].GetType() == type)
                {
                    count++;
                }
            }
        }
        return count;
    }
    public int GetCountActivateObjects()
    {
        int count = 0;
        for (int i = 0; i < _nodes.Count; i++)
        {
            if (_nodes[i].isReady == false)
            {
                count++;
            }
        }
        return count;
    }
    public int GetCountActivateFreeObjects(string name)
    {
        int count = 0;
        for (int i = 0; i < _nodes.Count; i++)
        {
            if (_nodes[i].isReady == true && _nodes[i].poolObject.GetName == name)
            {
                count++;
            }
        }
        return count;
    }
    public int GetCountActivateFreeObjects()
    {
        int count = 0;
        for (int i = 0; i < _nodes.Count; i++)
        {
            if (_nodes[i].isReady == true)
            {
                count++;
            }
        }
        return count;
    }
    public List<T> GetActivateObjects<T>() where T : IPoolable
    {
        List<T> poolables = new List<T>();

        for (int i = 0; i < _nodes.Count; i++)
        {
            if (_nodes[i].isReady == false)
            {
                poolables.Add((T)_nodes[i].poolObject);
            }
        }

        return poolables;
    }
}
