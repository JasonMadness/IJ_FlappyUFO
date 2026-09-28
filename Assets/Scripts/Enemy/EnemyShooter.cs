using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _interval = 3f;

    private EnemyLaserPool _laserPool;
    private Coroutine _shootRoutine;
    private readonly List<EnemyLaser> _activeLasers = new();

    public void Initialize(EnemyLaserPool laserPool)
    {
        _laserPool = laserPool;
    }

    private void OnEnable()
    {
        _shootRoutine = StartCoroutine(ShootLaser());
    }

    private void OnDisable()
    {
        if (_shootRoutine != null)
            StopCoroutine(_shootRoutine);

        foreach (EnemyLaser laser in _activeLasers)
            laser.ReadyToReturn -= OnLaserReadyToReturn;

        _activeLasers.Clear();
    }

    private IEnumerator ShootLaser()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);

        while (enabled)
        {
            yield return wait;
            Shoot();
        }
    }

    private void Shoot()
    {
        EnemyLaser laser = _laserPool.Get();
        laser.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
        laser.ReadyToReturn += OnLaserReadyToReturn;
        _activeLasers.Add(laser);
    }

    private void OnLaserReadyToReturn(IPoolable poolable)
    {
        if (poolable is not EnemyLaser laser) return;

        laser.ReadyToReturn -= OnLaserReadyToReturn;
        _activeLasers.Remove(laser);
        _laserPool.Release(laser);
    }
}