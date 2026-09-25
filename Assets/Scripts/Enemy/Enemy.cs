using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable<Enemy>
{
    private ObjectPool<Enemy> _pool;

    public void Initialize(ObjectPool<Enemy> pool)
    {
        _pool = pool;
    }

    public void ReturnToPool()
    {
        _pool.Release(this);
    }
}
