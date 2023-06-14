using System;
using Unity.VisualScripting.Dependencies.NCalc;
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
    }

    public void PlayBackgroundMusic()
    {
        // Сделать рандомом попозже
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
}

[Serializable]
public class Music
{
    public int levelNumber;
    public AudioClip audio;
}
