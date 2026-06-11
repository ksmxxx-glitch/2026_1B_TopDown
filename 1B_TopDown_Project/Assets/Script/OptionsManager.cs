using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance;

    public float bgmVolume = 1f;
    public float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadOption();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveOption()
    {
        PlayerPrefs.SetFloat("BGM", bgmVolume);
        PlayerPrefs.SetFloat("SFX", sfxVolume);

        PlayerPrefs.Save();

        Debug.Log("可记 历厘");
    }

    public void LoadOption()
    {
        bgmVolume =
            PlayerPrefs.GetFloat("BGM", 1f);

        sfxVolume =
            PlayerPrefs.GetFloat("SFX", 1f);

        Debug.Log("可记 阂矾坷扁");
    }

    public void SetBGMVolume(float value)
    {
        bgmVolume = value;

        SaveOption();
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;

        SaveOption();
    }
}