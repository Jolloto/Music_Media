using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public List<AudioClip> canciones; // Lista para meter clips de audio
    private AudioSource AudioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        // Reproduce la primera cancion cuando empieza
        PlaySong(currentSongIndex);
    }    


    public void PlaySong(int index)
    {
        if(index >= 0 && index < canciones.Count)
        {
            audioSource.clip = canciones[index];
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
