using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private EnemyLaserPool _laserPool;

    protected override void OnCreateItem(Enemy enemy)
    {
        enemy.GetComponent<EnemyShooter>().Initialize(_laserPool);
    }
}