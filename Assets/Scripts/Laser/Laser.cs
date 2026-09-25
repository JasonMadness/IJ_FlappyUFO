using UnityEngine;

public class Laser : MonoBehaviour, IPoolable<Laser>
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _lifetime = 2f;

    private ObjectPool<Laser> _pool;
    private float _flightTime;

    public void Initialize(ObjectPool<Laser> pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        _flightTime = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);

        _flightTime += Time.deltaTime;

        if (_flightTime >= _lifetime)
            ReturnToPool();
    }

    public void ReturnToPool()
    {
        if (_pool != null)
        {
            _pool.Release(this);
            return;
        }
    }
}
