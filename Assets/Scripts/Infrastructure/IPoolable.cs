using UnityEngine;

public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
{
    void Initialize(ObjectPool<T> pool);
    void ReturnToPool();
}