using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coin = 0;

    private void Awake()
    {
        instance = this;
    }
}