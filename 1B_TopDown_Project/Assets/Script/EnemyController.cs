using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float traceDistance = 10f;

    public GameObject coinPrefab;

    private Transform player;

    private void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        Vector2 direction =
            player.position - transform.position;

        // 플레이어가 너무 멀면 추적 안 함
        if (direction.magnitude > traceDistance)
            return;

        // 방향 정규화
        direction.Normalize();

        transform.position +=
            (Vector3)direction *
            moveSpeed *
            Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerController playerController =
            collision.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        // 커진 상태
        if (playerController.isPoweredUp)
        {
            Instantiate(
                coinPrefab,
                transform.position,
                Quaternion.identity);

            Destroy(gameObject);
        }
        else
        {
            PlayerHealth hp =
                collision.GetComponent<PlayerHealth>();

            if (hp != null)
            {
                hp.TakeDamage(1);
            }
        }
    }



}