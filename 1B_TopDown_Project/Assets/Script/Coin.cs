using UnityEngine;

public class Coin : MonoBehaviour
{
    public int expAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (GameDataManager.Instance != null)
        {
            GameDataManager.Instance.AddExp(expAmount);
        }

        Destroy(gameObject);
    }
}