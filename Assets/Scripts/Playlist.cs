using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public List<AudioSource> audioSources;
    

    void Start()
    {
        //Inicializar la lista de audioSources
        audioSources = new List<AudioSource>();

        //Agregar AudioSource a la lista

        AudioSource audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSources.Add(audioSource1);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSources.Add(audioSource2);
    }

}
