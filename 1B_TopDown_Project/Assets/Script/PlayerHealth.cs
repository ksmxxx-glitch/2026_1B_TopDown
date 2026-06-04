using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 10;
    public int currentHp;

    public Slider hpBar;

    void Start()
    {
        currentHp = maxHp;

        hpBar.maxValue = maxHp;
        hpBar.value = currentHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        hpBar.value = currentHp;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }
}
