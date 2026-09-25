using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool = new();

    public T Get()
    {
        if (_pool.Count == 0)
            Create();

        T item = _pool.Dequeue();
        item.gameObject.SetActive(true);
        return item;
    }

    public void Release(T item)
    {
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);
    }

    private void Create()
    {
        T newItem = Instantiate(_prefab, transform);
        newItem.Initialize(this);
        Release(newItem);
    }
}