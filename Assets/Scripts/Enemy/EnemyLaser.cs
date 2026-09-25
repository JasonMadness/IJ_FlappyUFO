using UnityEngine;

public class EnemyLaser : MonoBehaviour, IPoolable<EnemyLaser>
{
    [SerializeField] private float _speed = 15f;

    private ObjectPool<EnemyLaser> _pool;
    private LayerMask _ignoredLayer;

    private void Awake()
    {
        _ignoredLayer = LayerMask.GetMask("Enemy");
        GetComponent<Collider>().excludeLayers = _ignoredLayer;
    }

    public void Initialize(ObjectPool<EnemyLaser> pool)
    {
        _pool = pool;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        _pool.Release(this);
    }
}
