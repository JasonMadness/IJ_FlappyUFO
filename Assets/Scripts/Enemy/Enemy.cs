using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    public event Action<IPoolable> ReadyToReturn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Laser>(out _))
        {
            ReturnToPool();

        }    
    }

    public void ReturnToPool()
    {
        ReadyToReturn?.Invoke(this);
        ReadyToReturn = null;
    }
}