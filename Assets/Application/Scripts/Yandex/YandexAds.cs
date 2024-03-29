using System;
using UnityEngine;
using YG;

public class YandexAds : MonoBehaviour
{
    public static YandexAds Instance;

    private bool _isRewarded = false;
    public bool IsRewarded => _isRewarded;

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

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    private void Rewarded(int id)
    {
        if(id == 1)
        {
            OnAdRewarded();
        }
        else if(id == 2)
        {

        }
    }

    public void ShowInterstitial()
    {
        //TimerBeforeAdsYG.Instance.TimerAddShow();
        YandexGame.FullscreenShow();
    }

    public void ShowRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    /*public void OnAdOpen()
    {
        YandexSDK.Instance.IsAdRunning = true;
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }*/

    /*public void OnAdClose()
    {
        YandexSDK.Instance.IsAdRunning = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
        _isRewarded = false;
    }*/

    public void OnAdRewarded()
    {
        _isRewarded = true;
    }

    /*public void OnIterstitialAddClose(bool value)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }*/
}
