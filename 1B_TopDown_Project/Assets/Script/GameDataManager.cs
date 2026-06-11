using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData
{
    public float bestSurvivalTime = 0;
    public int totalExp = 0;
    public int level = 1;
    public int playCount = 0;
}

public class GameDataManager : MonoBehaviour
{

    public static GameDataManager Instance;
    public PlayerData playerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    // 중복 방지
        }

    }

    private void Start()
    {
        playerData = LoadData();

        playerData.playCount++;

        SaveData(playerData);
    }

    public void SaveData(PlayerData playerData)
    {
        string filePath =
            Application.persistentDataPath +
            "/player_data.json";

        Debug.Log(filePath);

        string json =
            JsonUtility.ToJson(playerData, true);

        System.IO.File.WriteAllText(
            filePath,
            json);

        Debug.Log("게임 데이터 저장됨");
    }

    public PlayerData LoadData()
    {
        string filePath = Application.persistentDataPath + "/player_data.json";
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("게임 데이터 로드됨: " + json);
            return playerData;
        }
        else
        {
            Debug.LogWarning("저장된 게임 데이터가 없습니다.");
            return new PlayerData();
        }
    }

    public void GameStart()
    {
        playerData = LoadData();

        SceneManager.LoadScene("Level_1");
    }

    public void PlayerDead()
{
    SaveData(playerData);

    SceneManager.LoadScene("GameOver");
}
    public void AddExp(int amount)
    {
        playerData.totalExp += amount;

        int level = 1;
        int requiredExp = 5;
        int totalRequiredExp = 0;

        while (playerData.totalExp >= totalRequiredExp + requiredExp)
        {
            totalRequiredExp += requiredExp;

            level++;

            requiredExp =
                Mathf.RoundToInt(
                    requiredExp * 1.25f + 5f);
        }

        playerData.level = level;

        SaveData(playerData);
    }

}
