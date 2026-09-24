using UnityEngine;

public class ObjectPoolReturner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IPoolable>(out IPoolable poolableObject))
        {
            poolableObject.ReturnToPool();
        }
    }
}
