using TMPro;
using UnityEngine;

public class DataUI : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text expText;
    public TMP_Text bestTimeText;

    void Update()
    {
        if (GameDataManager.Instance == null)
            return;

        PlayerData data =
            GameDataManager.Instance.playerData;

        levelText.text =
            "Level : " + data.level;

        expText.text =
            "EXP : " + data.totalExp;

        bestTimeText.text =
            "Best : " + data.bestSurvivalTime + " sec";
    }
}