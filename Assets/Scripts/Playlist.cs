using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playlist : MonoBehaviour
{
    [SerializeField] private AudioClip[] cancionesArray;
    [SerializeField]private Sprite[] ImagenesCanciones;

    [SerializeField] private Button PlayBoton;
    [SerializeField] private Button PausaBoton;
    [SerializeField] private Button PararBoton;
    [SerializeField] private Button LoopBoton;
    [SerializeField] private Button AleatorioBoton;
    [SerializeField] private Button SiguienteBoton;
    [SerializeField] private Button AnteriorBoton;

    float SliderValue;

     private Image imagen;
    [SerializeField] private AudioSource audio;
     private TMPro.TextMeshProUGUI TituloCancion;

    private float cancionLength;

    private float currentTiempoCancion;
    private bool isLooping = false;
    private int currentCancionesIndex = 0;

    void Start()
    {
        SliderValue = 0.5f;
        audio = GetComponent<AudioSource>();
        audio.Pause();
        PlayBoton.onClick.AddListener(PlayCancion);
        PausaBoton.onClick.AddListener(PausaCancion);
        PararBoton.onClick.AddListener(PararCancion);
        SiguienteBoton.onClick.AddListener(SiguienteCancion);
        AnteriorBoton.onClick.AddListener(AnteriorCancion);

   
    }   

    void OnGUI()
    {
        SliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), SliderValue, 0.0F, 1.0F);
        
        audio.volume = SliderValue;
    }

    void PlayCurrentCancion()
    {
        audio.clip = cancionesArray[currentCancionesIndex];
        audio.Play();
    }

    public void PlayCancion()
    {
        {
            audio.Play();
        }
        
    }

    public void SiguienteCancion()
    {
        currentCancionesIndex = (currentCancionesIndex + 1) % cancionesArray.Length;
        audio.clip = cancionesArray[currentCancionesIndex];
        audio.Play();
        cancionLength = audio.clip.length;
        imagen.sprite = ImagenesCanciones[currentCancionesIndex];
        TituloCancion.text = cancionesArray[currentCancionesIndex].name;

    }

    public void AnteriorCancion()
    {
       currentCancionesIndex = (currentCancionesIndex - 1 + cancionesArray.Length) % cancionesArray.Length;
        audio.clip = cancionesArray[currentCancionesIndex];
        audio.Play();
        cancionLength = audio.clip.length;
        imagen.sprite = ImagenesCanciones[currentCancionesIndex];
        TituloCancion.text = cancionesArray[currentCancionesIndex].name;

    }

    public void PausaCancion()
    {
        audio.Pause();
    }

    public void PararCancion()
    {
        audio.Stop();
    }
   
}
