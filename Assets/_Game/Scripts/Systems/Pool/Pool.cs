using System;
using System.Collections.Generic;

public class Pool
{
    public event Action OnBackInPool;
    public event Action<int, Type> OnNeedObjects;
    public event Action<IPoolable> OnAddObject;

    private List<Node> _projectileNodes = new List<Node>();

    private class Node
    {
        public Node(IPoolable newProjectile)
        {
            poolObject = newProjectile;
            isReadyToShoot = true;
        }

        public IPoolable poolObject;
        public bool isReadyToShoot;
    }
    public void AddObject(IPoolable poolable)
    {
        _projectileNodes.Add(new Node(poolable));
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

        foreach (var pool in _projectileNodes)
        {
            if (pool.isReadyToShoot && pool.poolObject.GetType() == type)
            {
                poolObject.Add(pool.poolObject);
                pool.isReadyToShoot = false;
                pool.poolObject.OnAddToPool += EndLifeTime;

                if (poolObject.Count >= count)
                {
                    return poolObject;
                }

                void EndLifeTime()
                {
                    pool.poolObject.OnAddToPool -= EndLifeTime;
                    pool.isReadyToShoot = true;
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

        foreach (var pool in _projectileNodes)
        {
            if (pool.isReadyToShoot)
            {
                poolObject.Add(pool.poolObject);
                pool.isReadyToShoot = false;
                pool.poolObject.OnAddToPool += EndLifeTime;

                if (poolObject.Count >= count)
                {
                    return poolObject;
                }

                void EndLifeTime()
                {
                    pool.poolObject.OnAddToPool -= EndLifeTime;
                    pool.isReadyToShoot = true;
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

        foreach (var pool in _projectileNodes)
        {
            if (pool.isReadyToShoot && pool.poolObject.GetName == name)
            {
                poolObject.Add(pool.poolObject);
                pool.isReadyToShoot = false;
                pool.poolObject.OnAddToPool += EndLifeTime;

                if (poolObject.Count >= count)
                {
                    return poolObject;
                }

                void EndLifeTime()
                {
                    pool.poolObject.OnAddToPool -= EndLifeTime;
                    pool.isReadyToShoot = true;
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
            for (int i = 0; i < _projectileNodes.Count; i++)
            {
                if (_projectileNodes[i].isReadyToShoot)
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
        for (int i = 0; i < _projectileNodes.Count; i++)
        {
            if (_projectileNodes[i].isReadyToShoot)
            {
                if (_projectileNodes[i].GetType() == type)
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
        for (int i = 0; i < _projectileNodes.Count; i++)
        {
            if (_projectileNodes[i].isReadyToShoot == false)
            {
                count++;
            }
        }
        return count;
    }
    public int GetCountActivateFreeObjects(string name)
    {
        int count = 0;
        for (int i = 0; i < _projectileNodes.Count; i++)
        {
            if (_projectileNodes[i].isReadyToShoot == true && _projectileNodes[i].poolObject.GetName == name)
            {
                count++;
            }
        }
        return count;
    }
    public List<T> GetActivateObjects<T>() where T : IPoolable
    {
        List<T> poolables = new List<T>();

        for (int i = 0; i < _projectileNodes.Count; i++)
        {
            if (_projectileNodes[i].isReadyToShoot == false)
            {
                poolables.Add((T)_projectileNodes[i].poolObject);
            }
        }

        return poolables;
    }
}
