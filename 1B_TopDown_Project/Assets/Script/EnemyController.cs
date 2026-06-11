using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Sprite[] spriteUp;
    public Sprite[] spriteDown;
    public Sprite[] spriteLeft;
    public Sprite[] spriteRight;

    public float moveSpeed = 2f;
    public float traceDistance = 30f;

    public GameObject coinPrefab;

    private SpriteRenderer sr;
    private Transform player;

    private Sprite[] currentSprites;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        currentSprites = spriteDown;

        if (currentSprites != null &&
            currentSprites.Length > 0)
        {
            sr.sprite = currentSprites[0];
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        Vector2 direction =
            player.position - transform.position;

        if (direction.magnitude > traceDistance)
            return;

        direction.Normalize();

        transform.position +=
            (Vector3)direction *
            moveSpeed *
            Time.deltaTime;

        // 방향별 스프라이트 변경
        if (Mathf.Abs(direction.x) >
            Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
                ChangeSprites(spriteRight);
            else
                ChangeSprites(spriteLeft);
        }
        else
        {
            if (direction.y > 0)
                ChangeSprites(spriteUp);
            else
                ChangeSprites(spriteDown);
        }
    }

    private void ChangeSprites(Sprite[] newSprites)
    {
        if (newSprites == null)
            return;

        if (newSprites.Length == 0)
            return;

        if (currentSprites == newSprites)
            return;

        currentSprites = newSprites;

        sr.sprite = currentSprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerController playerController =
            collision.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        if (playerController.isPoweredUp)
        {
            int coinCount = Random.Range(2, 5);

            for (int i = 0; i < coinCount; i++)
            {
                Vector2 offset =
                    Random.insideUnitCircle * 0.5f;

                Instantiate(
                    coinPrefab,
                    (Vector2)transform.position + offset,
                    Quaternion.identity);
            }

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