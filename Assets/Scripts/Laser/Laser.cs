using UnityEngine;

public class Laser : MonoBehaviour, IPoolable<Laser>
{
    [SerializeField] private float _speed = 15f;

    private ObjectPool<Laser> _pool;
    private LayerMask _ignoredLayer;

    private void Awake()
    {
        _ignoredLayer = LayerMask.GetMask("Player");
        GetComponent<Collider>().excludeLayers = _ignoredLayer;
    }

    public void Initialize(ObjectPool<Laser> pool)
    {
        _pool = pool;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
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
