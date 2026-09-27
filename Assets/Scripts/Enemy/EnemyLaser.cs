using UnityEngine;

public class EnemyLaser : MonoBehaviour, IPoolable<EnemyLaser>
{
    private const string EnemyMask = "Enemy";
    private const string PlayerLaserMask = "PlayerLaser";

    [SerializeField] private float _speed = 15f;

    private ObjectPool<EnemyLaser> _pool;
    private LayerMask _ignoredLayer;

    private void Awake()
    {
        _ignoredLayer = LayerMask.GetMask(EnemyMask, PlayerLaserMask);
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
