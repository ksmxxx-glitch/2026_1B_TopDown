using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform player;

    public float spawnRadius = 5f;

    public float spawnTime = 2f;

    void Start()
    {
        InvokeRepeating(
            nameof(SpawnEnemy),
            1f,
            spawnTime);
    }

    void SpawnEnemy()
    {
        Vector2 randomPos =
            (Vector2)player.position +
            Random.insideUnitCircle.normalized
            * spawnRadius;

        Instantiate(
            enemyPrefab,
            randomPos,
            Quaternion.identity);
    }
}