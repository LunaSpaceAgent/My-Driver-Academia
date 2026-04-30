using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // Variables
    public bool playMusic = true;
    [Header("Current Scene Information")]
    public int sceneIndex;
    public string sceneName;

    [Header("Music Manager Information")]
    public MusicManager musicManager;
    public int musicListCount;
    public int currentTrackSelected;
    public string currentSong;
    public float songLenght;

    [Header("Music Audio Source")]
    public AudioSource musicAudioSource;
    [Range(0.0f, 1.0f)]
    public float volume;
    public float audioSourcePlaytime;

    [Header("Music Player Components")]
    public GameObject musicPlayerPanel;
    public MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;

        musicManager = GetComponent<MusicManager>();
        musicAudioSource = GetComponent<AudioSource>();

        //currentTrackSelected = musicManager.musicList.IndexOf(musicManager.musicList.First());
        //musicListCount = musicManager.musicList.Count - 1;

        volume = 0.5f;

        //musicAudioSource.clip = musicManager.musicList.ElementAt(currentTrackSelected);
        currentSong = musicAudioSource.clip.name;
        songLenght = musicAudioSource.clip.length;

        //try
        /*{
            musicPlayerPanel = GameObject.Find("Canvas").transform.Find("Music Player Panel").gameObject;
            musicPlayer = musicPlayerPanel.GetComponent<MusicPlayer>();
            musicPlayer.SetMusicPlayer(musicAudioSource.clip.name, musicAudioSource.clip.length);
        }*/
        /*catch (NullReferenceException ex)
        {
            Debug.LogError($"Error finding Music Player Panel: {ex.Message}.");
        }*/

        if (playMusic)
        {
            PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        musicAudioSource.volume = volume;
        audioSourcePlaytime = musicAudioSource.time;
        /*if (musicPlayerPanel != null)
        {
            musicPlayer.MusicProgressBar(audioSourcePlaytime, musicAudioSource.clip.length);
        }*/
        if (audioSourcePlaytime >= songLenght)
        {
            StopMusic();
            NextTrack();
            if (playMusic)
            {
                PlayMusic();
            }
        }
    }

    // Functions
    public void NextTrack()
    {
        /*if (currentTrackSelected < musicManager.musicList.Count - 1)
        {
            currentTrackSelected++;
        }
        else if (currentTrackSelected >= musicManager.musicList.Count - 1)
        {
            currentTrackSelected = musicManager.musicList.IndexOf(musicManager.musicList.First());
        }
        musicAudioSource.clip = musicManager.musicList.ElementAt(currentTrackSelected);
        currentSong = musicAudioSource.clip.name;
        songLenght = musicAudioSource.clip.length;*/
        /*if (musicPlayerPanel != null)
        {
            musicPlayer.SetMusicPlayer(musicAudioSource.clip.name, musicAudioSource.clip.length);
        }*/
    }

    public void PlayMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Play();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void PauseMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Pause();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void StopMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Stop();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }
}
