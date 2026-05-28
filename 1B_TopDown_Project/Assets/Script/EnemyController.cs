using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float traceDistance = 10f;

    private Transform player;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        // 플레이어와 적 사이 거리 계산
        Vector2 direction = player.position - transform.position;

        // 플레이어가 너무 멀면 추적 안 함
        if (direction.magnitude > traceDistance)
            return;

        // 방향 정규화
        direction.Normalize();

        // 이동
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}