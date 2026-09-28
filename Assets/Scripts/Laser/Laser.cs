using System;
using UnityEngine;

public class Laser : MonoBehaviour, IPoolable
{
    [SerializeField] private float _speed = 15f;

    public event Action<IPoolable> ReadyToReturn;

    private LayerMask _ignoredLayer;

    private void Awake()
    {
        _ignoredLayer = LayerMask.GetMask("Player");
        GetComponent<Collider>().excludeLayers = _ignoredLayer;
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
        ReadyToReturn?.Invoke(this);
    }

    private void OnDisable()
    {
        ReadyToReturn = null;
    }
}