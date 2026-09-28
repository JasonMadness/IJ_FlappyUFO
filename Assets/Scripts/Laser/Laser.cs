using System;
using UnityEngine;

public class Laser : MonoBehaviour, IPoolable
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private LayerMask _ignoredLayer;
    [SerializeField] private Vector3 _direction;

    public event Action<IPoolable> ReadyToReturn;


    public void Awake()
    {
        GetComponent<Collider>().excludeLayers = _ignoredLayer;
    }

    private void Update()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
    }    

    private void OnTriggerEnter(Collider other)
    {
        ReturnToPool();
    }


    private void OnDisable()
    {
        ReadyToReturn = null;
    }

    public void ReturnToPool()
    {
        ReadyToReturn?.Invoke(this);
    }
}