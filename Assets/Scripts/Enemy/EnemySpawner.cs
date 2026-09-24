using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;
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
        Enemy enemy = _pool.Get();
        enemy.Initialize(_pool);
        enemy.transform.position = spawnPosition;
    }
}
