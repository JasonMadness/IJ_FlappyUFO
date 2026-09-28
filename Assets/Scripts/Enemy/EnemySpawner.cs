using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _pool;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private LaserSpawner _enemyLaserSpawner;
    [SerializeField] private float _boundary = 4f;
    [SerializeField] private float _spawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float randomY = Random.Range(-_boundary, _boundary);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        if (_pool.TryGet(out Enemy enemy) == false)
        {
            enemy = Instantiate(_prefab, transform);
        }

        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);
        enemy.ReadyToReturn += OnEnemyReadyToReturn;
    }

    private void OnEnemyReadyToReturn(IPoolable poolable)
    {
        if (poolable is Enemy enemy)
        {
            enemy.ReadyToReturn -= OnEnemyReadyToReturn;
            enemy.gameObject.SetActive(false);
            _pool.Release(enemy);
        }
    }
}