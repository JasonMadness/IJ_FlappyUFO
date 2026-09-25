using UnityEngine;

public class ObjectPoolReturner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPoolable>(out IPoolable poolable))
            poolable.ReturnToPool();
    }
}
