using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _interval = 3f;

    private LaserSpawner _laserSpawner;
    private Coroutine _shootRoutine;

    public void Initialize(LaserSpawner laserSpawner)
    {
        _laserSpawner = laserSpawner;
    }

    private void OnEnable()
    {
        _shootRoutine = StartCoroutine(ShootLaser());
    }

    private void OnDisable()
    {
        if (_shootRoutine != null)
            StopCoroutine(_shootRoutine);
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
        _laserSpawner.Spawn(_shootPoint.position, _shootPoint.rotation);
    }
}
