using System;
using UnityEngine;

public class Laser : MonoBehaviour, IPoolable
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private LayerMask _ignoredLayer;

    public event Action<IPoolable> ReadyToReturn;


    private void Awake()
    {
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