using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Playlist : MonoBehaviour
{
    [SerializeField] private AudioClip[] cancionesArray;
    [SerializeField] private Sprite[] ImagenesCanciones;

    [SerializeField] private Button PlayBoton;
    [SerializeField] private Button PausaBoton;
    [SerializeField] private Button PararBoton;
    [SerializeField] private Button LoopBoton;
    [SerializeField] private Button AleatorioBoton;
    [SerializeField] private Button MuteBoton;
    [SerializeField] private Button SiguienteBoton;
    [SerializeField] private Button AnteriorBoton;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Slider TimeSlider;
    [SerializeField] private AudioSource audio;
    [SerializeField] private Image imagen;
    [SerializeField] private TMPro.TextMeshProUGUI TituloCancion;
    [SerializeField] private TMPro.TextMeshProUGUI TimeText;

    float SliderValue;

    private float cancionLength;

    private float currentTiempoCancion;
    private bool isLooping = false;
    private int currentCancionesIndex = 0;

    private bool isPaused = false;
    private bool isStopped = false;

    void Start()
    {
        VolumeSlider.value = 0.5f;
        audio.Pause();

        VolumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
        TimeSlider.onValueChanged.AddListener(OnTimeSliderValueChanged);
    }

    void OnTimeSliderValueChanged(float value)
    {
        audio.time = value * audio.clip.length;
    }

    void OnVolumeSliderValueChanged(float value)
    {
        audio.volume = value;
    }
    public void mute()
    {
        audio.mute = !audio.mute;
        ColorBlock colors = MuteBoton.colors;
        colors.selectedColor = (audio.mute) ? Color.red : Color.white;
        MuteBoton.colors = colors;
    }
    public void OnGUI()
    {
        SliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), SliderValue, 0.0F, 1.0F);
        audio.volume = SliderValue;
    }

    void Update()
    {
        if (audio.clip.length - audio.time > 1) {
            TimeSlider.value = audio.time / audio.clip.length;

            float currentTime = audio.time;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 1000);

            // Format the time as mm:ss:ms
            string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

            // Update the text with the formatted time
            TimeText.text = formattedTime;
        }
        EndSongEvent();
        audio.volume = VolumeSlider.value;
    }

    public void randomSong()
    {
        System.Random random = new System.Random();
        currentCancionesIndex = random.Next(0, cancionesArray.Length);
        print(currentCancionesIndex);
        updateSong();
        PlayCurrentCancion();
    }

    public void EndSongEvent()
    {
        if (!audio.isPlaying && !isPaused && !isStopped)
        {
            if (isLooping)
            {
                PlayCancion();
                TimeSlider.value = 0;
                return;
            }
            SiguienteCancion();
        }
    }

    public void loopCancion()
    {
        ColorBlock colors = LoopBoton.colors;
        isLooping = !isLooping;
        colors.normalColor = (isLooping) ? Color.green : Color.white;
        colors.selectedColor = (isLooping) ? Color.green : Color.white;
        LoopBoton.colors = colors;
        print(isLooping);
    }

    void updateSong()
    {
        audio.clip = cancionesArray[currentCancionesIndex];
        cancionLength = audio.clip.length;
        imagen.sprite = ImagenesCanciones[currentCancionesIndex];
        TituloCancion.text = cancionesArray[currentCancionesIndex].name;
        TimeSlider.value = 0;
    }

    public void PlayCurrentCancion()
    {
        audio.clip = cancionesArray[currentCancionesIndex];

        audio.Play();
        isPaused = false;
        isStopped = false;
    }

    public void PlayCancion()
    {
        if (isPaused == true) { audio.UnPause(); }
        else { audio.Play(); }        
    }

    public void SiguienteCancion()
    {
        currentCancionesIndex = (currentCancionesIndex + 1) % cancionesArray.Length;
        updateSong();
        PlayCurrentCancion();
    }

    public void AnteriorCancion()
    {
        currentCancionesIndex = (currentCancionesIndex - 1 + cancionesArray.Length) % cancionesArray.Length;
        updateSong();
        PlayCurrentCancion();

    }

    public void PausaCancion()
    {
        audio.Pause();
        isPaused = true;
        isStopped = false;
    }

    public void PararCancion()
    {
        audio.Stop();
        isPaused = false;
        isStopped = true;
    }
   
}
