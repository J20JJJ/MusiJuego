using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusica : MonoBehaviour
{

    public AudioClip musicClip; // Aqu� es donde guardamos el archivo de audio que importaste

    private AudioSource audioSource; // Este ser� el componente que reproducir� el audio

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtenemos el componente AudioSource del objeto actual
        audioSource.clip = musicClip; // Asignamos el archivo de audio al componente AudioSource
        audioSource.Play(); // Empezamos a reproducir el audio
    }
}
