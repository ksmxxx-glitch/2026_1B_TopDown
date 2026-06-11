using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider expBar;

    void Update()
    {
        if (GameDataManager.Instance == null)
            return;

        PlayerData data =
            GameDataManager.Instance.playerData;

        int totalExp = data.totalExp;

        int level = 1;
        int requiredExp = 5;
        int totalRequiredExp = 0;

        while (totalExp >= totalRequiredExp + requiredExp)
        {
            totalRequiredExp += requiredExp;

            level++;

            requiredExp =
                Mathf.RoundToInt(
                    requiredExp * 1.25f + 5f);
        }

        int currentLevelExp =
            totalExp - totalRequiredExp;

        expBar.maxValue = requiredExp;
        expBar.value = currentLevelExp;
    }
}