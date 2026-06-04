using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player =
                collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.ActivatePowerUp();
            }

            Destroy(gameObject);
        }
    }
}