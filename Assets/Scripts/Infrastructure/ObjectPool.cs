using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    private readonly Queue<T> _pool = new();

    public bool TryGet(out T item)
    {
        if (_pool.Count > 0)
        {
            item = _pool.Dequeue();
            return true;
        }

        item = null;
        return false;
    }

    public void Release(T item)
    {
        _pool.Enqueue(item);
    }
}