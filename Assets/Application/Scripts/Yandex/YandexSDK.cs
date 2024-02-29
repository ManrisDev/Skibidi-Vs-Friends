using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private Localization _localization;

    private LevelLoader _levelLoader;
    private const string _saveKey = "SaveData";
    private string _language;
    public bool IsAdRunning;

    public static YandexSDK Instance;

    public string CurrentLanguage => _language;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetData();
            _levelLoader = FindObjectOfType<LevelLoader>();
            _language = YandexGame.EnvironmentData.language;
            _localization.SetLanguage(_language);
            LevelLoader.Instance.LoadLevel(SaveData.Instance.Data.CurrentLevel, GameReady);
        }
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetData;
    }

    private void GameReady()
    {
        YandexGame.GameReadyAPI();
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (!IsAdRunning)
            MuteAudio(inBackground);
    }

    public void MuteAudio(bool value)
    {
        Time.timeScale = value ? 0f : 1f;
        AudioListener.pause = value;
        AudioListener.volume = value ? 0f : 1f;
        SoundsManager.Instance.Mute("music", value);
        SoundsManager.Instance.Mute("effects", value);
    }

    private void GetData()
    {
        SaveData.Instance.Data.Coins = YandexGame.savesData.Coins;
        SaveData.Instance.Data.Score = YandexGame.savesData.Score;
        SaveData.Instance.Data.CurrentLevel = YandexGame.savesData.CurrentLevel;
        SaveData.Instance.Data.FakeLevel = YandexGame.savesData.FakeLevel;
        SaveData.Instance.Data.muteEffects = YandexGame.savesData.muteEffects;
        SaveData.Instance.Data.muteMusic = YandexGame.savesData.muteMusic;

        SaveManager.Save(_saveKey, SaveData.Instance._data);
    }
}