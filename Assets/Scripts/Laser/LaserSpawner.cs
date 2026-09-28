using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool<Laser> _pool;
    [SerializeField] private Laser _prefab;

    private readonly List<Laser> _activeLasers = new();

    public Laser Spawn(Vector3 position, Quaternion rotation)
    {
        if (_pool.TryGet(out Laser laser) == false)
        {
            laser = Instantiate(_prefab, transform);
            laser.gameObject.SetActive(false);
        }

        laser.transform.SetPositionAndRotation(position, rotation);
        laser.gameObject.SetActive(true);
        laser.ReadyToReturn += OnLaserReadyToReturn;
        _activeLasers.Add(laser);
        return laser;
    }

    private void OnLaserReadyToReturn(IPoolable poolable)
    {
        if (poolable is Laser laser)
        {
            laser.ReadyToReturn -= OnLaserReadyToReturn;
            _activeLasers.Remove(laser);
            laser.gameObject.SetActive(false);
            _pool.Release(laser);
        }
    }

    private void OnDisable()
    {
        foreach (Laser laser in _activeLasers)
            laser.ReadyToReturn -= OnLaserReadyToReturn;

        _activeLasers.Clear();
    }
}
