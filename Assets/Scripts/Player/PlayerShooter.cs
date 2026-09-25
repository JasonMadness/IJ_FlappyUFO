using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LaserPool _laserPool;

    public void Shoot()
    {
        Laser laser = _laserPool.Get();
        laser.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
    }
}
