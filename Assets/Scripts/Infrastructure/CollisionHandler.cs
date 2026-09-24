using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        CollisionDetected?.Invoke();
    }
}
