using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable<Enemy>
{
    private ObjectPool<Enemy> _pool;

    public void Initialize(ObjectPool<Enemy> pool)
    {
        _pool = pool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Laser>(out _))
            ReturnToPool();
    }

    public void ReturnToPool()
    {
        _pool.Release(this);
    }
}
