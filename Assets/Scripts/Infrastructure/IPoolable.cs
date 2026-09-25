using UnityEngine;

public interface IPoolable
{
    void ReturnToPool();
}

public interface IPoolable<T> : IPoolable where T : MonoBehaviour, IPoolable<T>
{
    void Initialize(ObjectPool<T> pool);
}
