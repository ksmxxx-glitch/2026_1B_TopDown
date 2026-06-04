using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;

    public float spawnTime = 10f;

    void Start()
    {
        InvokeRepeating(
            nameof(SpawnItem),
            3f,
            spawnTime);
    }

    void SpawnItem()
    {
        Vector2 pos =
            new Vector2(
                Random.Range(-8, 8),
                Random.Range(-8, 8));

        Instantiate(
            itemPrefab,
            pos,
            Quaternion.identity);
    }
}