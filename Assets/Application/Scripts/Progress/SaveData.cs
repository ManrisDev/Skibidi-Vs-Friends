using System;
using UnityEngine;
using YG;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;

    [SerializeField] public DataHolder _data;

    public DataHolder Data => _data;

    private const string _leaderboardTxt = "Leaderboard";
    private const string _saveKey = "SaveData";

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

    public void NewData()
    {
        _data = new DataHolder();
    }

   /* private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _data = new DataHolder();

            SaveManager.Reset(_saveKey, _data);
            SaveYandex();
        }
    }*/

    private void OnDisable()
    {
        Save();
        SaveYandex();
    }

    public void Save()
    {
        SaveManager.Save(_saveKey, _data);
    }

    public void Load()
    {
        var data = SaveManager.Load<DataHolder>(_saveKey);
        _data = data;
    }

    public void SetLeaderboardScore()
    {
        int current = _data.Score;
    }

    public void SaveYandex()
    {
        YandexGame.savesData.Coins = Data.Coins;
        YandexGame.savesData.Score = Data.Score;
        YandexGame.savesData.CurrentLevel = Data.CurrentLevel;
        YandexGame.savesData.FakeLevel = Data.FakeLevel;
        YandexGame.savesData.muteEffects = Data.muteEffects;
        YandexGame.savesData.muteMusic = Data.muteMusic;

        YandexGame.SaveProgress();
    }
}

[Serializable]
public class DataHolder
{
    public int Coins;
    public int Score;
    public int CurrentLevel;
    public int FakeLevel;
    public bool muteMusic;
    public bool muteEffects;
}
