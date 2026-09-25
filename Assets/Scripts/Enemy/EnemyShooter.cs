using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private EnemyLaserPool _laserPool;
    [SerializeField] private float _interval = 3f;

    private void OnEnable()
    {
        StartCoroutine(ShootLaser());
    }

    public void Initialize(EnemyLaserPool laserPool)
    {
        _laserPool = laserPool;
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
    }
}
