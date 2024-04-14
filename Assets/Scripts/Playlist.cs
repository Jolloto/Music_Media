using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public List<AudioClip> songs; // Lista para meter clips de audio
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySong(currentSongIndex);
    }    


    public void PlaySong(int index)
    {
        if(index >= 0 && index < songs.Count)
        {
            audioSource.clip = songs[index];
            audioSource.Play();
            currentSongIndex = index;
        }
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void Resume()
    {
        audioSource.UnPause();
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
