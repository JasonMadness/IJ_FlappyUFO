using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LaserSpawner _laserSpawner;

    public void Shoot()
    {
        _laserSpawner.Spawn(_shootPoint.position, _shootPoint.rotation);
    }
}