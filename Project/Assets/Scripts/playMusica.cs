using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusica : MonoBehaviour
{

    public AudioClip musicClip; // Aquí es donde guardamos el archivo de audio que importaste

    private AudioSource audioSource; // Este será el componente que reproducirá el audio

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtenemos el componente AudioSource del objeto actual
        audioSource.clip = musicClip; // Asignamos el archivo de audio al componente AudioSource
        audioSource.Play(); // Empezamos a reproducir el audio
    }
}
