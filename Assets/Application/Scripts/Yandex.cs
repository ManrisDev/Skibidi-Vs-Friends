using UnityEngine;
using Agava.YandexGames;

public class Yandex : MonoBehaviour
{
    public void Awake()
    {
        YandexGamesSdk.Initialize();

        if(YandexGamesSdk.IsInitialized == true)
        {
            InterstitialAd.Show();
        }
    }
}
