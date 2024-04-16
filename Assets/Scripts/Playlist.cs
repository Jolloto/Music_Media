using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public List<AudioClip> canciones;
    private AudioSource playerAudioSource;


    void Start()
    {

       
    }    

    private void Awake() 
    {
        playerAudioSource = GetComponent<AudioSource>();
        playerAudioSource.clip = canciones[0];
        playerAudioSource.Play();
    }
 }

