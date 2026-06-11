using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject itemPrefab;

    public float spawnTime = 5f;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj =
                GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null)
                player = playerObj.transform;
        }

        float level = 1;

        if (GameDataManager.Instance != null &&
            GameDataManager.Instance.playerData != null)
        {
            level =
                GameDataManager.Instance.playerData.level;
        }

        spawnTime =
            Mathf.Max(2f, 10f - level);

        InvokeRepeating(
            nameof(SpawnItem),
            1f,
            spawnTime);
    }

    void SpawnItem()
    {
        if (player == null)
            return;

        Vector2 pos =
            (Vector2)player.position +
            Random.insideUnitCircle * 3f;

        Instantiate(
            itemPrefab,
            pos,
            Quaternion.identity);
    }
}