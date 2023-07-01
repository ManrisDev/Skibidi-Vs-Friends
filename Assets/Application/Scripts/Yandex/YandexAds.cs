using Agava.YandexGames;
using UnityEngine;

public class YandexAds : MonoBehaviour
{
    public static YandexAds Instance;

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

    public void ShowInterstitial()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show(OnAdOpen, OnIterstitialAddClose);
#endif
    }

    public void ShowRewardAd()
    {
        VideoAd.Show(OnAdOpen, null, OnAdClose);
#if UNITY_WEBGL && !UNITY_EDITOR
#endif
    }

    public void OnAdOpen()
    {
        YandexSDK.Instance.IsAdRunning = true;
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }

    public void OnAdClose()
    {
        YandexSDK.Instance.IsAdRunning = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }

    public void OnIterstitialAddClose(bool value)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
