using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource audio_source;

    private void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void crash_sound()
    {//crash_sound=sonido de choque
        audio_source.clip = audios[0];
        audio_source.Play();
    }

    public void music()
    {//music=musica
        audio_source.clip = audios[1];
        audio_source.Play();
    }
}
