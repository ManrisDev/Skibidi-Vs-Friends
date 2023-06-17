using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance = null;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource effectsAudioSource;

    [Header("Clips")]
    [SerializeField] private Music[] backgroundMusic;
    [SerializeField] private Sound[] effects;

    private float _startVolume;

    private float _fadeDuration = 0.5f;
    
    //private int currentClip = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        /*else
            Destroy(gameObject);*/
    }

    private void Update()
    {
        if (!musicAudioSource.isPlaying)
        {
            PlayBackgroundMusic();
        }
    }

    private void Start()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        Music m = Array.Find(backgroundMusic, music => music.levelNumber == levelNumber + 1);

        if (m == null)
        {
            Debug.LogError("Music for level " + levelNumber + " not found.");
            return;
        }

        musicAudioSource.clip = backgroundMusic[levelNumber].audio;
        musicAudioSource.Play();
        _startVolume = musicAudioSource.volume;
    }

    public void PlayBackgroundMusic()
    {
        // ������� �������� �������
        /*if (currentClip == backgroundMusic.Length)
            currentClip = 0;*/
        //musicAudioSource.clip = backgroundMusic[currentClip++].audio;
        musicAudioSource.Play();
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(effects, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogError(name + " not found.");
            return;
        }

        effectsAudioSource.PlayOneShot(s.audioClip);
    }

    public void Mute(string source, bool value)
    {
        if (source.Equals("music"))
            musicAudioSource.mute = value;
        else
            effectsAudioSource.mute = value;
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        float elapsedTime = 0f;

        while(elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            musicAudioSource.volume = Mathf.Lerp(_startVolume, 0.0f, elapsedTime / _fadeDuration);
            yield return null;
        }

        musicAudioSource.Stop();
    }
}

[Serializable]
public class Music
{
    public int levelNumber;
    public AudioClip audio;
}