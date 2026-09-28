using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LaserPool _laserPool;

    private readonly List<Laser> _activeLasers = new();

    public void Shoot()
    {
        Laser laser = _laserPool.Get();
        laser.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
        laser.ReadyToReturn += OnLaserReadyToReturn;
        _activeLasers.Add(laser);
    }

    private void OnLaserReadyToReturn(IPoolable poolable)
    {
        if (poolable is not Laser laser) return;

        laser.ReadyToReturn -= OnLaserReadyToReturn;
        _activeLasers.Remove(laser);
        _laserPool.Release(laser);
    }

    private void OnDisable()
    {
        foreach (Laser laser in _activeLasers)
            laser.ReadyToReturn -= OnLaserReadyToReturn;

        _activeLasers.Clear();
    }
}