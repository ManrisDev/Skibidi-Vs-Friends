using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBehaviour : MonoBehaviour
{
    public static LevelBehaviour Instance;

    [SerializeField] CoinManager _coinManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SaveData.Instance.Data.CurrentLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SaveData.Instance.Data.Score += ForceManager.Instance.NumberOfForce;
            SaveData.Instance.Save();
        }
        else
        {
            next = 1;
            SaveData.Instance.Data.CurrentLevel = 1;
            SaveData.Instance.Data.Score += ForceManager.Instance.NumberOfForce;
            SaveData.Instance.Save();
        }
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexAds.Instance.ShowInterstitial();
#endif
        SceneManager.LoadScene(next);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
